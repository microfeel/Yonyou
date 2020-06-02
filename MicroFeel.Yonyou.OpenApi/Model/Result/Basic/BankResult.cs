using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class BankResult : ApiResult
    {
        public Bank Bank { get; set; }
    }
    public class BankListResult : DbListResult<Bank>
    {
        [JsonPropertyName("bank")]
        public override List<Bank> List { get; set; }
    }
}

