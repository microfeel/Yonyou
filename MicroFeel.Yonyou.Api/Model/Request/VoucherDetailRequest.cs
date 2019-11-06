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
    public class VoucherDetailRequest : DbRequest
    {
        public VoucherDetailRequest(CallerRequest callerRequest)
        {
            AppKey = callerRequest.AppKey;
            FromAccount = callerRequest.FromAccount;
            ToAccount = callerRequest.ToAccount;
            Token = callerRequest.Token;
        }

        /// <summary>
        /// 起始制单日期
        /// </summary>
        [JsonPropertyName("date_begin")]
        public DateTime Date_begin { get; set; }
        /// <summary>
        /// 结束制单日期
        /// </summary>
        [JsonPropertyName("date_end")]
        public DateTime Date_end { get; set; }
        /// <summary>
        /// 起始科目编码
        /// </summary>
        [JsonPropertyName("code_begin")]
        public string Code_begin { get; set; }
        /// <summary>
        /// 结束科目编码
        /// </summary>
        [JsonPropertyName("code_end")]
        public string Code_end { get; set; }
        /// <summary>
        /// 是否核销 凭证状态
        /// </summary>
        [JsonPropertyName("bdelete")]
        public bool Bdelete { get; set; }
        /// <summary>
        /// 外部系统号
        /// </summary>
        [JsonPropertyName("coutno_id")]
        public string Coutno_id { get; set; }
    }
}
