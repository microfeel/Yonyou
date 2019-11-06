
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 凭证列表结果消息
    /// </summary>
    public class VoucherListResult : ListResult
    {
        /// <summary>
        /// 凭证列表
        /// </summary>
        [JsonPropertyName("voucherlist")]
        public Voucherlist Voucherlist { get; set; }
    }

}
