using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 凭证列表请求实体
    /// </summary>
    public class VoucherListRequest : DbRequest
    {
        public VoucherListRequest(CallerRequest callerRequest)
        {
            AppKey = callerRequest.AppKey;
            FromAccount = callerRequest.FromAccount;
            ToAccount = callerRequest.ToAccount;
            Token = callerRequest.Token;
        }

        /// <summary>
        /// 凭证日期(from)
        /// </summary>
        [JsonPropertyName("bill_date_from")]
        public string Bill_date_from { get; set; }
        /// <summary>
        /// 凭证日期(to)
        /// </summary>
        [JsonPropertyName("bill_date_to")]
        public string Bill_date_to { get; set; }
        /// <summary>
        /// 科目编码(from)
        /// </summary>
        [JsonPropertyName("bill_code_from")]
        public string Bill_code_from { get; set; }
        /// <summary>
        /// 科目编码(to)
        /// </summary>
        [JsonPropertyName("bill_code_to")]
        public string Bill_code_to { get; set; }
        /// <summary>
        /// 外部系统编码
        /// </summary>
        [JsonPropertyName("coutno_id")]
        public string Coutno_id { get; set; }
        /// <summary>
        /// 凭证编号
        /// </summary>
        [JsonPropertyName("coutno_id")]
        public string Cno_id { get; set; }
        /// <summary>
        /// 凭证类别字
        /// </summary>
        [JsonPropertyName("csign")]
        public string Csign { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        [JsonPropertyName("cbill")]
        public string Cbill { get; set; }

    }
}
