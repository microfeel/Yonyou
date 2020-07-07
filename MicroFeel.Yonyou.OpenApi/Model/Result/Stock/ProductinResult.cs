using System;
    public class ProductinResult : ApiResult
    {
        public Productin Productin { get; set; }
    }

    public class ProductinListResult : DbListResult<Productin>
    {
       
        [JsonPropertyName("productinlist")]
        public override List<Productin> List { get; set; }
    }
}