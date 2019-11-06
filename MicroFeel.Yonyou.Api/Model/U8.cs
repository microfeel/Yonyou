using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{

    public class U8
    {
        /// <summary>
        /// 	U8地址
        /// </summary>
        [JsonPropertyName("sys_host")]
        public string SysHost { get; set; }
        /// <summary>
        /// U8系统ID
        /// </summary>
        [JsonPropertyName("sys_id")]
        public string SysId { get; set; }
    }

}
