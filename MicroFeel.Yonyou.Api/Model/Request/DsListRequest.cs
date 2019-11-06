using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 数据API请求基类
    /// </summary>
    public class DsListRequest : CallerRequest
    {
        /// <summary>
        /// 数据源序号（默认取应用的第一个数据源）
        /// </summary>
        [JsonPropertyName("sequence_begin")]
        public int SequenceBegin { get; set; } = 1;
        /// <summary>
        /// 结束数据源序号
        /// </summary>
        [JsonPropertyName("sequence_end")]
        public int SequenceEnd { get; set; } = 100;
    }
}
