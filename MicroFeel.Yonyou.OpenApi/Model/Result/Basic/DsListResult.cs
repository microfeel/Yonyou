using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DsListResult : ApiResult
    {
        [JsonPropertyName("datasource")]
        public IEnumerable<Datasource> Datasources { get; set; }
    }
}