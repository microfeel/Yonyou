

using System;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Voucher
    {
        /// <summary>
        /// 	制单人
        /// </summary>
        [JsonPropertyName("bill")]
        public string Bill { get; set; }
        /// <summary>
        /// 科目编码
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        /// <summary>
        /// 外部系统号
        /// </summary>
        [JsonPropertyName("coutno_id")]
        public string CoutnoId { get; set; }
        /// <summary>
        /// 贷方合计
        /// </summary>
        [JsonPropertyName("credit_amount")]
        public decimal CreditAmount { get; set; }
        /// <summary>
        /// 制单日期
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        /// <summary>
        /// 借方合计
        /// </summary>
        [JsonPropertyName("debit_amount")]
        public decimal DebitAmount { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        [JsonPropertyName("digest")]
        public string Digest { get; set; }
        /// <summary>
        /// 凭证编号
        /// </summary>
        [JsonPropertyName("i_id")]
        public string IId { get; set; }
        /// <summary>
        /// 凭证字
        /// </summary>
        [JsonPropertyName("ino_id")]
        public string InoId { get; set; }
    }

}
