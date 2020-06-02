using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 凭证详情
    /// </summary>
    public class VoucherDetail
    {
        /// <summary>
        /// 是否核销 凭证状态
        /// </summary>
        [JsonPropertyName("bdelete")]
        public bool Bdelete { get; set; }
        /// <summary>
        /// 现金流量项目
        /// </summary>
        [JsonPropertyName("ccashitem")]
        public string Ccashitem { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        [JsonPropertyName("bill")]
        public string Bill { get; set; }
        /// <summary>
        /// iid 应该是凭证号
        /// </summary>
        [JsonPropertyName("i_id")]
        public string IId { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        [JsonPropertyName("digest")]
        public string Digest { get; set; }
        /// <summary>
        /// 现金流量贷方金额
        /// </summary>
        [JsonPropertyName("ccash_mc")]
        public decimal CcashMc { get; set; }
        /// <summary>
        /// 制单日期
        /// </summary>
        [JsonPropertyName("date")]
        public string Date { get; set; }
        /// <summary>
        /// 	出纳
        /// </summary>
        [JsonPropertyName("ccashier")]
        public string Ccashier { get; set; }
        /// <summary>
        /// --有错标识2 作废标识1 正常 0
        /// </summary>
        [JsonPropertyName("iflag")]
        public string Iflag { get; set; }
        /// <summary>
        /// 审核
        /// </summary>
        [JsonPropertyName("ccheck")]
        public string Ccheck { get; set; }
        /// <summary>
        /// 现金流量借方金额
        /// </summary>
        [JsonPropertyName("ccash_md_f")]
        public decimal CcashMdF { get; set; }
        /// <summary>
        /// 人员编码
        /// </summary>
        [JsonPropertyName("cperson_id")]
        public string CpersonId { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>
        [JsonPropertyName("cdept_id")]
        public string CdeptId { get; set; }
        /// <summary>
        /// 原币贷方金额
        /// </summary>
        [JsonPropertyName("mc_f")]
        public string McF { get; set; }
        /// <summary>
        /// 贷方金额
        /// </summary>
        [JsonPropertyName("mc")]
        public string Mc { get; set; }
        /// <summary>
        /// 现金流量贷方金额
        /// </summary>
        [JsonPropertyName("ccash_mc_f")]
        public string CcashMcF { get; set; }
        /// <summary>
        /// 借方金额
        /// </summary>
        [JsonPropertyName("md")]
        public string Md { get; set; }
        /// <summary>
        /// 原币借方金额
        /// </summary>
        [JsonPropertyName("md_f")]
        public string MdF { get; set; }
        /// <summary>
        /// 贷方数量
        /// </summary>
        [JsonPropertyName("nc_s")]
        public string NcS { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        [JsonPropertyName("csup_id")]
        public string CsupId { get; set; }
        /// <summary>
        /// 外部系统号
        /// </summary>
        [JsonPropertyName("coutno_id")]
        public string CoutnoId { get; set; }
        /// <summary>
        /// 币种名称
        /// </summary>
        [JsonPropertyName("cexch_name")]
        public string CexchName { get; set; }
        /// <summary>
        /// 科目编码
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        /// <summary>
        /// 凭证编号
        /// </summary>
        [JsonPropertyName("ino_id")]
        public string InoId { get; set; }
        /// <summary>
        /// 记账
        /// </summary>
        [JsonPropertyName("cbook")]
        public string Cbook { get; set; }
        /// <summary>
        /// 借方数量
        /// </summary>
        [JsonPropertyName("nd_s")]
        public string NdS { get; set; }
        /// <summary>
        /// 项目大类
        /// </summary>
        [JsonPropertyName("citem_id")]
        public string CitemId { get; set; }
        /// <summary>
        /// 现金流量借方金额
        /// </summary>
        [JsonPropertyName("ccash_md")]
        public string CcashMd { get; set; }
        /// <summary>
        /// 分录行号
        /// </summary>
        [JsonPropertyName("inid")]
        public string Inid { get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        [JsonPropertyName("nfrat")]
        public string Nfrat { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        [JsonPropertyName("citem_class")]
        public string CitemClass { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        [JsonPropertyName("ccus_id")]
        public string CcusId { get; set; }
    }

}
