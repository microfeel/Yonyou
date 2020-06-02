using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api.Model.Result{
    public class ConsignmentResult : ApiResult
    {
        public Consignment Consignment { get; set; }
    }

    public class ConsignmentListResult : DbListResult<Consignment>
    {
        [JsonPropertyName("consignmentlist")]
        public override List<Consignment> List { get; set; }
    }
}