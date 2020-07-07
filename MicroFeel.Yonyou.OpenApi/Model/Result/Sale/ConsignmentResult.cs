using System;
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