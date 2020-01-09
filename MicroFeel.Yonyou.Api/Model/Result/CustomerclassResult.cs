using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class CustomerclassResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("customerclass")]
        public Customerclass Customerclass { get; set; }
    }
    public class CustomerclassListResult : DbListResult<Customerclass>
    {
        [JsonPropertyName("customerclass")]
        public override List<Customerclass> List { get; set; }
    }
}

