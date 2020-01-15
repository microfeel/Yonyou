using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class Customer_BankResult : ApiResult
    {
        public Customer_Bank Customer_Bank { get; set; }
    }
    public class Customer_BankListResult : DbListResult<Customer_Bank>
    {
        [JsonPropertyName("customer_bank")]
        public override List<Customer_Bank> List { get; set; }
    }
}

