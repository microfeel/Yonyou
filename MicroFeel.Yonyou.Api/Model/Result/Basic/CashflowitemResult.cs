using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class CashflowitemResult : ApiResult
    {
        [JsonPropertyName("cashflowitem")]
        public Cashflowitem Cashflowitem { get; set; }
    }
    public class CashflowitemListResult : DbListResult<Cashflowitem>
    {
        [JsonPropertyName("cashflowitem")]
        public override List<Cashflowitem> List { get; set; }
    }
}

