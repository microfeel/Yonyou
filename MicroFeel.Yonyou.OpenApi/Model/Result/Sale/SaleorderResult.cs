using System;
    public class SaleorderResult : ApiResult
    {
        public Saleorder Saleorder { get; set; }
    }

    public class SaleorderListResult : DbListResult<Saleorder>
    {
        [JsonPropertyName("saleorderlist")]
        public override List<Saleorder> List { get; set; }
    }
}