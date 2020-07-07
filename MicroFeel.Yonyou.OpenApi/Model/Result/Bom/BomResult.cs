using System;
    public class BomResult : ApiResult
    {
        [JsonPropertyName("bom")]
        public Bom Bom { get; set; }
    }

    public class BomListResult : DbListResult<Bom>
    {
        [JsonPropertyName("bom")]
        public override List<Bom> List { get; set; }
    }
}