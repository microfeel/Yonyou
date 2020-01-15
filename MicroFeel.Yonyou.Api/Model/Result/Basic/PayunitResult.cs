using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PayunitResult : ApiResult
    {
        [JsonPropertyName("payunit")]
        public Payunit Payunit { get; set; }
    }
    public class PayunitListResult : DbListResult<Payunit>
    {
        [JsonPropertyName("payunit")]
        public override List<Payunit> List { get; set; }
    }
}

