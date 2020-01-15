using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DutytypeResult : ApiResult
    {
        public Dutytype Dutytype { get; set; }
    }
    public class DutytypeListResult : DbListResult<Dutytype>
    {
        [JsonPropertyName("dutytype")]
        public override List<Dutytype> List { get; set; }
    }
}

