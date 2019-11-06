using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 开放平台 API 基类   \s+(.*)\s(\w+)/(\w+)   /// <summary>\n /// $1 \n /// </summary> \n /// <return></return>\n public object $3_$2(){return null;}\n
    /// </summary>
    public abstract class Api
    {
        protected static readonly string ERR_MSG_SDK_RUNTIME_ERROR = "OpenAPI-SDK Runtime Error.";
        protected const int MAX_TIMES_TRADEID_RETRY = 20;

        protected string _appKey;
        protected string _appSecret;
        protected string _fromAccount;
        protected string _toAccount;
        protected ILogger<Api> _logger;

        /// <summary>
        /// 调用不同API使用的路径前缀
        /// </summary>
        protected string pathprefix;

        /// <summary>
        /// 默认的Json序列化选项
        /// </summary>
        public static readonly JsonSerializerOptions JsOptions = new JsonSerializerOptions { IgnoreNullValues = true, IgnoreReadOnlyProperties = true };

        /// <summary>
        /// 构造API
        /// </summary>
        /// <param name="prefix">路径前缀</param>
        /// <param name="logger">日志记录器</param>
        public Api(string prefix, ILogger<Api> logger = null)
        {
            pathprefix = prefix;
            _logger = logger ?? NullLogger<Api>.Instance;
        }

        /// <summary>
        /// 接口调用
        /// </summary>
        /// <typeparam name="UrlParamType">http命令参数类型</typeparam>
        /// <typeparam name="ResultType">返回类型</typeparam>
        /// <param name="urlParameter">参数对象实例</param>
        /// <param name="postData">需要post的对象序列化结果</param>
        /// <returns>结果对象</returns>
        internal async Task<ResultType> CallAsync<UrlParamType, ResultType>(UrlParamType urlParameter, string postData = "", [CallerMemberName] string membername = "")
            where UrlParamType : ApiRequest
            where ResultType : ApiResult
        {
            _logger.LogInformation($"MemberName:{membername}");
            membername = membername.ToLower().Replace("async", "");
            var index = membername.LastIndexOf('_');
            var method = "";
            //token和trade方法没有method
            if (index != -1)
            {
                method = membername.Substring(0, index);
            }
            var resourceid = membername.Substring(index + 1);
            //特殊处理对token和trade
            method = string.IsNullOrWhiteSpace(method) ? "" : "/" + method;

            var Url = $"{BaseUrl}{pathprefix}/{resourceid}{method}{urlParameter}";
            _logger.LogInformation($"{resourceid}/{method} UrlParam is :{Url}");

            HttpResponseMessage response;
            using (var httpClient = new HttpClient())
            {
                switch (method)
                {
                    case "post":
                    case "verify":
                    case "unverify":
                    case "add":
                    case "audit":
                    case "abandon":
                    case "query":
                    case "change":
                    case "check":
                        //对于POST请求,需要分别序列化url参数和body参数
                        if (string.IsNullOrEmpty(postData))
                        {
                            _logger.LogError($"{nameof(postData)} 不能为空");
                            throw new ArgumentNullException(nameof(postData));
                        }
                        response = await httpClient.PostAsync(Url, new StringContent(postData));
                        break;
                    case "get":
                    case "batch_get":
                    case "tasks":
                    case "history":
                    case "flowenabled":
                    case "buttonstate":
                    default:
                        response = await httpClient.GetAsync(Url);
                        break;
                }
                try
                {
                    response.EnsureSuccessStatusCode();
                    string resultString = await response.Content.ReadAsStringAsync();
                    _logger.LogInformation($"Call completed .ResultString is :{resultString}");
                    return JsonSerializer.Deserialize<ResultType>(resultString);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "请求异常");
                    throw e;
                }
            }
        }
        /// <summary>
        /// 获取标准的请求类型实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected async Task<T> GetRequestTypeAsync<T>() where T : ApiRequest, new()
        {
            T t = new T();

            switch (t.GetType().Name)
            {
                case nameof(TokenRequest):
                    t = new TokenRequest { AppKey = _appKey, AppSecret = _appSecret, FromAccount = _fromAccount } as T;
                    break;
                case nameof(CallerRequest):
                    t = new CallerRequest
                    {
                        AppKey = _appKey,
                        FromAccount = _fromAccount,
                        ToAccount = _toAccount,
                        Token = await TokenManager.GetTokenAsync(BaseUrl, _appKey, _appSecret, _fromAccount, _toAccount),
                    } as T;
                    break;
                case nameof(DsRequest):
                    t = new DsRequest
                    {
                        AppKey = _appKey,
                        FromAccount = _fromAccount,
                        ToAccount = _toAccount,
                        Token = await TokenManager.GetTokenAsync(BaseUrl, _appKey, _appSecret, _fromAccount, _toAccount),
                    } as T;
                    break;
                case nameof(BaseRequest):
                default:
                    t = new BaseRequest
                    {
                        AppKey = _appKey,
                        FromAccount = _fromAccount,
                        Token = await TokenManager.GetTokenAsync(BaseUrl, _appKey, _appSecret, _fromAccount, _toAccount),
                    } as T;
                    break;
            }
            return t;
        }

        /// <summary>
        /// 初始化API
        /// </summary>
        /// <param name="baseUrl">openapi基地址</param>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecret">应用密钥</param>
        /// <param name="fromAccount">提供方</param>
        /// <param name="toAccount">调用方</param>
        public virtual void Init(string baseUrl, string appKey, string appSecret, string fromAccount, string toAccount)
        {
            BaseUrl = baseUrl;
            _appKey = appKey;
            _appSecret = appSecret;
            _fromAccount = fromAccount;
            _toAccount = toAccount;
        }

        /// <summary>
        /// 请求的基地址
        /// </summary>
        protected string BaseUrl { get; private set; }
    }
}
