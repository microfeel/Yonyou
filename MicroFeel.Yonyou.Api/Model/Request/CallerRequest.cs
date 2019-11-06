using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 基本请求类型
    /// </summary>
    public class CallerRequest : BaseRequest
    {
        /// <summary>
        /// 提供方id
        /// </summary>
        [JsonPropertyName("to_account")]
        public string ToAccount { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}&to_account={ToAccount}";
        }
    }
}
