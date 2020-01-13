using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{
    public class BomResult : Bom, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class BomListResult : DbListResult<BomBatch>
    {
        [JsonPropertyName("bom")]
        public override List<BomBatch> List { get; set; }
    }
}