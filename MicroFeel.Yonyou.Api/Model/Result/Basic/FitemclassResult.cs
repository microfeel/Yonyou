using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class FitemclassListResult : DbListResult<Fitemclass>
    {
        [JsonPropertyName("fitemclass")]
        public override List<Fitemclass> List { get; set; }
    }
}

