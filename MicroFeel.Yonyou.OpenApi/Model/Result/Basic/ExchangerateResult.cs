using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class ExchangerateResult : ApiResult
    {
        public Exchangerate Exchangerate { get; set; }
    }
    public class ExchangerateListResult : DbListResult<Exchangerate>
    {
        [JsonPropertyName("exchangerate")]
        public override List<Exchangerate> List { get; set; }
    }
}

