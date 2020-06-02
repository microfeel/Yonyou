using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PurchasereturnResult : ApiResult
    {
        [JsonPropertyName("purchaseretur")]
        public Purchasereturn Purchasereturn { get; set; }
    }

    public class PurchasereturnListResult : DbListResult<Purchasereturn>
    {
       
        [JsonPropertyName("purchasereturnlist")]
        public override List<Purchasereturn> List { get; set; }
    }
}
