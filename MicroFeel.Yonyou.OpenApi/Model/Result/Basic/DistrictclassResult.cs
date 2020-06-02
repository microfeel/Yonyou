using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DistrictclassResult : ApiResult
    {
        public Districtclass Districtclass { get; set; }
    }
    public class DistrictclassListResult : DbListResult<Districtclass>
    {
        [JsonPropertyName("districtclass")]
        public override List<Districtclass> List { get; set; }
    }
}
