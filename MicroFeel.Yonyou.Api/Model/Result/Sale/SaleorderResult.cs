using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api.Model.Result{
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