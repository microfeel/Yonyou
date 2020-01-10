using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{
    public class PurchasereceiptResult : Purchasereceipt, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class PurchasereceiptListResult : DbListResult<Purchasereceipt>
    {
      
        [JsonPropertyName("purchasereceiptlist")]
        public override List<Purchasereceipt> List { get; set; }
    }
}