using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class VendorclassResult : ApiResult
    {
        public Vendorclass Vendorclass { get; set; }
    }

    public class VendorclassListResult : DbListResult<Vendorclass>
    {
        [JsonPropertyName("vendorclass")]
        public override List<Vendorclass> List { get; set; }
    }
}
