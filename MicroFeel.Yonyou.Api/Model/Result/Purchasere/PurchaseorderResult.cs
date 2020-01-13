using System;
    public class PurchaseorderResult : Purchaseorder, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class PurchaseorderListResult : DbListResult<Purchaseorder>
    {
        [JsonPropertyName("purchaseorderlist")]
        public override List<Purchaseorder> List { get; set; }
    }
}