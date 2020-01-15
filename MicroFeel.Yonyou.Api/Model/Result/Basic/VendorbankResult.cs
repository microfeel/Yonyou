using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class VendorbankResult : ApiResult
    {
        public Vendorbank Vendorbank { get; set; }
    }
    public class VendorbankListResult : DbListResult<Vendorbank>
    {
        [JsonPropertyName("vendorbank")]
        public override List<Vendorbank> List { get; set; }
    }
}
