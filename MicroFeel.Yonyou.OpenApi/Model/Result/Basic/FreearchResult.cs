using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class FreearchResult : ApiResult
    {
        public Freearch Freearch { get; set; }
    }
    public class FreearchListResult : DbListResult<Freearch>
    {
        [JsonPropertyName("freearch")]
        public override List<Freearch> List { get; set; }
    }
}

