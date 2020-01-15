using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DefineResult : ApiResult
    {
        [JsonPropertyName("define")]
        public Define Define { get; set; }
    }

    public class DefineListResult : DbListResult<Define>
    {
        [JsonPropertyName("define")]
        public override List<Define> List { get; set; }
    }
}

