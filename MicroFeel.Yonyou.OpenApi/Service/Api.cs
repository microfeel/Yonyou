using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using MicroFeel.Yonyou.Api.Model.Request;
using MicroFeel.Yonyou.Api.Model.Result;
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
        public static System.Text.Json.JsonSerializerOptions JsOptions { get; set; }

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
        /// 静态构造,初始化JSOptions
        /// </summary>
        static Api()
        {
            JsOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true,
                PropertyNameCaseInsensitive = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All)
            };
            JsOptions.Converters.Add(new DateTimeConverter());
        }

        /// <summary>
        /// 接口调用
        /// </summary>
        /// <typeparam name="TUrlParam">http命令参数类型</typeparam>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="urlParameter">参数对象实例</param>
        /// <param name="postData">需要post的对象序列化结果</param>
        /// <returns>结果对象</returns>
        internal async Task<TResult> CallAsync<TUrlParam, TResult>(TUrlParam urlParameter, string postData = "", [CallerMemberName] string membername = "")
            where TUrlParam : ApiRequest
            where TResult : ApiResult
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

            var Url = $"{BaseUrl}{pathprefix}/{resourceid}{(string.IsNullOrWhiteSpace(method) ? "" : "/" + method)}{urlParameter}";
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
                        var content = new StringContent(postData);
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        response = await httpClient.PostAsync(Url, content);
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
                    var runType = typeof(TResult);
                    if (runType.Name.StartsWith("DbListResult"))
                    {
                        var t2 = runType.GenericTypeArguments[0];
                        var typename = runType.Namespace + "." + t2.Name + "ListResult";
                        Type t = Type.GetType(typename);
                        if (t == null)
                        {
                            throw new Exception($"无法找到目标类型:{typename}");
                        }
                        return JsonSerializer.Deserialize(resultString, t, JsOptions) as TResult;
                    }
                    else
                    {
                        return JsonSerializer.Deserialize<TResult>(resultString, JsOptions);
                    }
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

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="req"></param>
        /// <param name="id"></param>
        /// <param name="dsSequence"></param>
        /// <param name="callername"></param>
        /// <returns></returns>
        public async Task<TResult> GetSync<TResult>(string id, int dsSequence = 1, [CallerMemberName] string callername = "")
            where TResult : ApiResult
        {
            pathprefix = "api";
            var req = new SingleRequest()
            {
                AppKey = _appKey,
                FromAccount = _fromAccount,
                ToAccount = _toAccount,
                Token = await TokenManager.GetTokenAsync(BaseUrl, _appKey, _appSecret, _fromAccount, _toAccount),
                DsSequence = dsSequence,
                Id = id
            };
            var result = await CallAsync<SingleRequest, TResult>(req, "", callername);
            if (result.Errcode == "0")
            {
                return result;
            }
            else
            {
                throw new ApiException($"({result.Errcode}){result.Errmsg}");
            }
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="req"></param>
        /// <param name="id"></param>
        /// <param name="dsSequence"></param>
        /// <param name="callername"></param>
        /// <returns></returns>
        public async Task<TResult> GetSync<TRequest, TResult>(TRequest req, int dsSequence = 1, [CallerMemberName] string callername = "")
             where TRequest : ApiRequest
            where TResult : ApiResult
        {
            pathprefix = "api";
            var result = await CallAsync<TRequest, TResult>(req, "", callername);
            if (result.Errcode == "0")
            {
                return result;
            }
            else
            {
                throw new ApiException($"({result.Errcode}){result.Errmsg}");
            }
        }


        /// <summary>
        /// 获取批量
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="req"></param>
        /// <param name="dsSequence"></param>
        /// <param name="callername"></param>
        /// <returns></returns>
        public async Task<DbListResult<TData>> GetsSync<TRequest, TData>(TRequest req, int dsSequence = 1, [CallerMemberName] string callername = "")
         where TRequest : ApiRequest
        {
            pathprefix = "api";

            var result = await CallAsync<TRequest, DbListResult<TData>>(req, "", callername);
            //var result = await CallAsync<TRequest, DbListResult<TData>>(req, "", callername);
            if (result.Errcode == "0")
            {
                return result;
            }
            else
            {
                throw new ApiException($"({result.Errcode}){result.Errmsg}");
            }
        }

        public async Task<DbListResult<TResult>> GetsSync<TResult>(int dsSequence = 1, [CallerMemberName] string callername = "", int pageNumber = 1, int pageSize = 10)
        {
            pathprefix = "api";
            var req = new DbRequest()
            {
                AppKey = _appKey,
                FromAccount = _fromAccount,
                ToAccount = _toAccount,
                Token = await TokenManager.GetTokenAsync(BaseUrl, _appKey, _appSecret, _fromAccount, _toAccount),
                Ds_sequence = dsSequence,
                Page_index = pageNumber,
                Rows_per_page = pageSize
            };
            return await GetsSync<DbRequest, TResult>(req, dsSequence, callername);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResult"></typeparam> 
        /// <param name="req"></param>
        /// <param name="data"></param>
        /// <param name="dsSequence"></param>
        /// <param name="sync"></param>
        /// <param name="callername"></param>
        /// <returns></returns>
        public async Task<TResult> AddSync<TRequest, TResult>(TRequest req, string data, int dsSequence = 1, bool sync = true, [CallerMemberName] string callername = "")
         where TRequest : ApiRequest
         where TResult : ApiResult
        {
            pathprefix = "api";
            var result = await CallAsync<TRequest, TResult>(req, data, callername);
            if (result.Errcode == "0")
            {
                return result;
            }
            else
            {
                throw new ApiException($"({result.Errcode}){result.Errmsg}");
            }
        }

        /// <summary>
        /// 添加出入库
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <param name="req"></param>
        /// <param name="data"></param>
        /// <param name="bizId">上级单号</param>
        /// <param name="dsSequence"></param>
        /// <param name="sync"></param>
        /// <param name="callername"></param>
        /// <returns></returns>
        public async Task<DbResult> AddSync<TData>(TData data, int dsSequence = 1, bool sync = true, string bizId = null, [CallerMemberName] string callername = "")
        {
            var req = new BuinessRequest
            {
                AppKey = _appKey,
                FromAccount = _fromAccount,
                ToAccount = _toAccount,
                Token = await TokenManager.GetTokenAsync(BaseUrl, _appKey, _appSecret, _fromAccount, _toAccount),
                BizId = bizId,
                TradeId = bizId ?? await TradeidManager.GetTradeidAsync(BaseUrl, _appKey, _appSecret, _fromAccount, _toAccount),
                DsSequence = dsSequence,
                Sync = sync ? 1 : 0
            };
            //var json = "{\"" + typeof(TData).Name.ToLower() + "\":" + JsonConvert.SerializeObject(data) + "}";
            var json = "{\"" + typeof(TData).Name.ToLower() + "\":" + JsonSerializer.Serialize(data, Api.JsOptions) + "}";
            return await AddSync<BuinessRequest, DbResult>(req, json, dsSequence, sync, callername);
        }
    }
}
