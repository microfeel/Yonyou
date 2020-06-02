using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api.Model.Result{
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