using System;
    public class PurchaseinResult : Purchasein, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class PurchaseinListResult : DbListResult<Purchasein>, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
        [JsonPropertyName("purchaseinlist")]
        public override List<Purchasein> List { get; set; }
    }
}