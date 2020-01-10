using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{
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