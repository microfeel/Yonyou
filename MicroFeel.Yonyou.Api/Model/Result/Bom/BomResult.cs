using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api.Model.Result{
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