using System;
    public class PurchasereturnResult : Purchasereturn, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class PurchasereturnListResult : DbListResult<Purchasereturn>
    {
       
        [JsonPropertyName("purchasereturnlist")]
        public override List<Purchasereturn> List { get; set; }
    }
}