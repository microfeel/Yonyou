using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class ExchangerateResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("exchangerate")]
        public Exchangerate Exchangerate { get; set; }
    }
    public class ExchangerateListResult : DbListResult<Exchangerate>
    {
        [JsonPropertyName("exchangerate")]
        public override List<Exchangerate> List { get; set; }
    }
}

