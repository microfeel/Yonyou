using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class ListResult<TResult> : ApiResult where TResult : class
    {
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
        /// <summary>
        /// 总行数
        /// </summary>
        [JsonPropertyName("row_count")]
        public int Row_count { get; set; } = 20;
        /// <summary>
        /// 页数
        /// </summary>
        [JsonPropertyName("page_count")]
        public int Page_count { get; set; } = 20;
    }
}