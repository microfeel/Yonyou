using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Db
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        [JsonPropertyName("db_type")]
        public string DbType { get; set; }
        /// <summary>
        /// 数据库地址
        /// </summary>
        [JsonPropertyName("db_host")]
        public string DbHost { get; set; }
        /// <summary>
        /// 数据库账套
        /// </summary>
        [JsonPropertyName("db_scheme")]
        public string DbScheme { get; set; }
    }

}
