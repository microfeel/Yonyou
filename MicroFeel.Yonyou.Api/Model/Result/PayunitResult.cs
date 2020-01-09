using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PayunitResult : Payunit, IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
    }
    public class PayunitListResult : DbListResult<Payunit>
    {
        [JsonPropertyName("payunit")]
        public override List<Payunit> List { get; set; }
    }
}

