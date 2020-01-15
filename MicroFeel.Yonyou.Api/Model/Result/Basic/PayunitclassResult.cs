using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PayunitclassResult : ApiResult
    {
        public Payunitclass Payunitclass { get; set; }
    }
    public class PayunitclassListResult : DbListResult<Payunitclass>
    {
        [JsonPropertyName("payunitclass")]
        public override List<Payunitclass> List { get; set; }
    }
}

