using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PayunitclassResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("payunitclass")]
        public Payunitclass Payunitclass { get; set; }
    }
    public class PayunitclassListResult : DbListResult<Payunitclass>
    {
        [JsonPropertyName("payunitclass")]
        public override List<Payunitclass> List { get; set; }
    }
}

