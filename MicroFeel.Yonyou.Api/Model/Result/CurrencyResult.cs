using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class CurrencyResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }
    }
    public class CurrencyListResult : DbListResult<Currency>
    {
        [JsonPropertyName("currency")]
        public override List<Currency> List { get; set; }
    }
}

