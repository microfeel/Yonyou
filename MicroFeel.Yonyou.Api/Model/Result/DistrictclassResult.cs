using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DistrictclassResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("districtclass")]
        public Districtclass Districtclass { get; set; }
    }
    public class DistrictclassListResult : DbListResult<Districtclass>
    {
        [JsonPropertyName("districtclass")]
        public override List<Districtclass> List { get; set; }
    }
}
