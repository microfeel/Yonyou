using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class SettlestyleResult : ApiResult
    {
        public Settlestyle Settlestyle { get; set; }
    }
    public class SettlestyleListResult : DbListResult<Settlestyle>
    {
        [JsonPropertyName("settlestyle")]
        public override List<Settlestyle> List { get; set; }
    }
}

