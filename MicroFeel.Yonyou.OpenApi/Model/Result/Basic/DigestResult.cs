using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DigestResult : ApiResult
    {
        public Digest Digest { get; set; }
    }
    public class DigestListResult : DbListResult<Digest>
    {
        [JsonPropertyName("digest")]
        public override List<Digest> List { get; set; }
    }
}

