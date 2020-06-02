using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PurchaserequisitionResult : ApiResult
    {
        public Purchaserequisition Purchaserequisition { get; set; }
    }

    public class PurchaserequisitionListResult : DbListResult<Purchaserequisition>
    {
      
        [JsonPropertyName("purchaserequisitionlist")]
        public override List<Purchaserequisition> List { get; set; }
    }
}
