using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PurchaseinvoiceResult : ApiResult
    {
        [JsonPropertyName("purchaseinvoicelist")]
        public Purchaseinvoice Purchaseinvoice { get; set; }
    }

    public class PurchaseinvoiceListResult : DbListResult<Purchaseinvoice>
    {
        [JsonPropertyName("purchaseinvoicelist")]
        public override List<Purchaseinvoice> List { get; set; }
    }
}
