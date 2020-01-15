using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class OtherinResult : ApiResult
    {
        public Otherin Otherin { get; set; }
    }

    public class OtherinListResult : DbListResult<Otherin>
    {
        [JsonPropertyName("otherinlist")]
        public override List<Otherin> List { get; set; }
    }
}
