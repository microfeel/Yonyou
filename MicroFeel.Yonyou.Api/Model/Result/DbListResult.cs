using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DbResult : ApiResult
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("tradeid")]
        public string Tradeid { get; set; }
    }
    public abstract class DbListResult<TModel> : ApiResult
    {        /// <summary>
             /// 页号
             /// </summary>
        [JsonPropertyName("page_index")]
        public string PageIndex { get; set; }
        /// <summary>
        /// 每页行数
        /// </summary>
        [JsonPropertyName("rows_per_page")]
        public string RowsPerPage { get; set; }
        [JsonPropertyName("page_count")]
        public string PageCount { get; set; }
        [JsonPropertyName("row_count")]
        public string RowCount { get; set; }
        public abstract List<TModel> List { get; set; }
    }
}
