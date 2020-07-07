using System;
    public class SaleinvoiceResult : ApiResult
    {
        public Saleinvoice Saleinvoice { get; set; }
    }

    public class SaleinvoiceListResult : DbListResult<Saleinvoice>
    {
        [JsonPropertyName("saleinvoicelist")]
        public override List<Saleinvoice> List { get; set; }
    }
}