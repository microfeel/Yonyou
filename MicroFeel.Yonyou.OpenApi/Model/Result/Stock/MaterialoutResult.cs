using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class MaterialoutResult : ApiResult
    {
        public Materialout Materialout { get; set; }
    }

    public class MaterialoutListResult : DbListResult<Materialout>
    {
      
        [JsonPropertyName("materialoutlist")]
        public override List<Materialout> List { get; set; }
    }
}
