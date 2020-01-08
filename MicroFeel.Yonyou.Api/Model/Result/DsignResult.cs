using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DsignResult : Dsign, IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
    }

    public class DsignListResult : DbListResult<Dsign>
    {
        [JsonPropertyName("dsign")]
        public override List<Dsign> List { get; set; }
    }
}
