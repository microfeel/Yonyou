using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DsResult : ApiResult
    {
        public Datasource Datasource { get; set; }
    }
}