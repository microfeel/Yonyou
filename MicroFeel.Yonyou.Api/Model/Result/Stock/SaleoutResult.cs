using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class SaleoutResult : ApiResult
    {
        public Saleout Saleout { get; set; }
    }

    public class SaleoutListResult : DbListResult<Saleout>
    {
        
        [JsonPropertyName("saleoutlist")]
        public override List<Saleout> List { get; set; }
    }
}
