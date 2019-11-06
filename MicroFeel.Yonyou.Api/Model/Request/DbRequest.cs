using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 数据API请求基类
    /// </summary>
    public class DbRequest : CallerRequest
    {
        /// <summary>
        /// 数据源序号（默认取应用的第一个数据源）
        /// </summary>
        [JsonPropertyName("ds_sequence")]
        public int Ds_sequence { get; set; }
        /// <summary>
        /// 页号
        /// </summary>
        [JsonPropertyName("page_index")]
        public int Page_index { get; set; } = 1;
        /// <summary>
        /// 每页行数
        /// </summary>
        [JsonPropertyName("rows_per_page")]
        public int Rows_per_page { get; set; } = 20;
    }
}
