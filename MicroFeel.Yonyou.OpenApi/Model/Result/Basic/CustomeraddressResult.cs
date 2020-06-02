using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class CustomeraddressResult : ApiResult
    {
        public Customeraddress Customeraddress { get; set; }
    }
    public class CustomeraddressListResult : DbListResult<Customeraddress>
    {
        [JsonPropertyName("customeraddress")]
        public override List<Customeraddress> List { get; set; }
    }
}

