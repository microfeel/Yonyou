using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{
    public class PurchaserequisitionResult : Purchaserequisition, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class PurchaserequisitionListResult : DbListResult<Purchaserequisition>
    {
      
        [JsonPropertyName("purchaserequisitionlist")]
        public override List<Purchaserequisition> List { get; set; }
    }
}