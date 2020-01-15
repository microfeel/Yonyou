using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class VendorResult : ApiResult
    {
        public Vendor Vendor { get; set; }
    }

    public class VendorListResult : DbListResult<Vendor>
    {
        [JsonPropertyName("vendor")]
        public override List<Vendor> List { get; set; }
    }

}
