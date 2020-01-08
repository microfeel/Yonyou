using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DutytypeResult : Dutytype, IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
    }
    public class DutytypeListResult : DbListResult<Dutytype>
    {
        [JsonPropertyName("dutytype")]
        public override List<Dutytype> List { get; set; }
    }
}

