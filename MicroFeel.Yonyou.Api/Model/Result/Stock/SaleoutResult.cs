using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{
    public class SaleoutResult : Saleout, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class SaleoutListResult : DbListResult<Saleout>
    {
        
        [JsonPropertyName("saleoutlist")]
        public override List<Saleout> List { get; set; }
    }
}