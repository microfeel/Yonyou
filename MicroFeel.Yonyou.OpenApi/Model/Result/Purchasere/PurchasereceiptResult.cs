using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PurchasereceiptResult : ApiResult
    {
        [JsonPropertyName("purchasereceipt")]
        public Purchasereceipt Purchasereceipt { get; set; }
    }

    public class PurchasereceiptListResult : DbListResult<Purchasereceipt>
    {
      
        [JsonPropertyName("purchasereceiptlist")]
        public override List<Purchasereceipt> List { get; set; }
    }
}
