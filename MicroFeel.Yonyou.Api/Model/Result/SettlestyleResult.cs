using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class SettlestyleResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("settlestyle")]
        public Settlestyle Settlestyle { get; set; }
    }
    public class SettlestyleListResult : DbListResult<Settlestyle>
    {
        [JsonPropertyName("settlestyle")]
        public override List<Settlestyle> List { get; set; }
    }
}

