using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class UnitResult : ApiResult
    {
        public Unit Unit { get; set; }
    }
    public class UnitListResult : DbListResult<Unit>
    {
        [JsonPropertyName("unit")]
        public override List<Unit> List { get; set; }
    }
}

