using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class CurrencyResult : ApiResult
    {
        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }
    }
    public class CurrencyListResult : DbListResult<Currency>
    {
        [JsonPropertyName("currency")]
        public override List<Currency> List { get; set; }
    }
}

