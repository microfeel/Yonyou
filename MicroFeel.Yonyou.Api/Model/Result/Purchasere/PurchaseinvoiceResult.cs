using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{
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