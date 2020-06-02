using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class OtheroutResult : ApiResult
    {
        public Otherout Otherout { get; set; }
    }

    public class OtheroutListResult : DbListResult<Otherout>
    {
        [JsonPropertyName("otheroutlist")]
        public override List<Otherout> List { get; set; }
    }
}
