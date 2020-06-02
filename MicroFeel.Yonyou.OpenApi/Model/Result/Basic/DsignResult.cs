using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DsignResult : ApiResult
    {
        public Dsign Dsign { get; set; }
    }

    public class DsignListResult : DbListResult<Dsign>
    {
        [JsonPropertyName("dsign")]
        public override List<Dsign> List { get; set; }
    }
}
