using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 数据API请求基类
    /// </summary>
    public class DsRequest : CallerRequest
    {
        /// <summary>
        /// 数据源序号（默认取应用的第一个数据源）
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; } = 1;

        public override string ToString()
        {
            return base.ToString() + "&id=" + Id;
        }
    }
}
