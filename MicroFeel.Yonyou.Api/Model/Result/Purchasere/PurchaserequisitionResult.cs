using System;
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