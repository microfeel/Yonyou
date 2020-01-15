using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class FitemListResult : DbListResult<Fitem>
    {
        [JsonPropertyName("fitem")]
        public override List<Fitem> List { get; set; }
    }
}

