using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{
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