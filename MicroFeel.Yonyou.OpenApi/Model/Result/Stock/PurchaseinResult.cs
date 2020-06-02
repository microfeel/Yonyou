using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PurchaseinResult : ApiResult
    {
        public Purchasein Purchasein { get; set; }
    }

    public class PurchaseinListResult : DbListResult<Purchasein>
    {
      
        [JsonPropertyName("purchaseinlist")]
        public override List<Purchasein> List { get; set; }
    }
}
