using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class CustomerResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }
    }
    public class CustomerListResult : DbListResult<Customer>
    {
        [JsonPropertyName("customer")]
        public override List<Customer> List { get; set; }
    }
}