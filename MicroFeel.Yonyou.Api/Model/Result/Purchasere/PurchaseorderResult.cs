using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PurchaseorderResult : ApiResult
    {
        [JsonPropertyName("purchaseorder")]
        public Purchaseorder Purchaseorder { get; set; }
    }

    public class PurchaseorderListResult : DbListResult<Purchaseorder>
    {
        [JsonPropertyName("purchaseorderlist")]
        public override List<Purchaseorder> List { get; set; }
    }
}
