using System;
    public class SaleoutResult : Saleout, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class SaleoutListResult : DbListResult<Saleout>, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
        [JsonPropertyName("saleoutlist")]
        public override List<Saleout> List { get; set; }
    }
}