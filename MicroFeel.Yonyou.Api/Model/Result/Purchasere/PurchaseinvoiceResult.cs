using System;
    public class PurchaseinvoiceResult : Purchaseinvoice, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class PurchaseinvoiceListResult : DbListResult<Purchaseinvoice>
    {
        [JsonPropertyName("purchaseinvoicelist")]
        public override List<Purchaseinvoice> List { get; set; }
    }
}