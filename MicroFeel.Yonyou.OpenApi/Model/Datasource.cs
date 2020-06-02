using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 数据源
    /// </summary>
    public class Datasource
    {
        /// <summary>
        /// 数据源序号
        /// </summary>
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
        /// <summary>
        /// U8系统对象
        /// </summary>
        [JsonPropertyName("U8")]
        public U8 U8 { get; set; }
        /// <summary>
        /// 数据库对象
        /// </summary>
        [JsonPropertyName("db")]
        public Db Db { get; set; }
    }

}
