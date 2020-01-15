using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class ExpitemclassResult : ApiResult
    {
        public Expitemclass Expitemclass { get; set; }
    }
    public class ExpitemclassListResult : DbListResult<Expitemclass>
    {
        [JsonPropertyName("expitemclass")]
        public override List<Expitemclass> List { get; set; }
    }
}

