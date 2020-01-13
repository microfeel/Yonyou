using System;
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