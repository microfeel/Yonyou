using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class VenpriceadjustResult : ApiResult
    {
        public Venpriceadjust Venpriceadjust { get; set; }
    }

    public class VenpriceadjustListResult : DbListResult<Venpriceadjust>
    {
        [JsonPropertyName("venpriceadjustlist")]
        public override List<Venpriceadjust> List { get; set; }
    }
}
