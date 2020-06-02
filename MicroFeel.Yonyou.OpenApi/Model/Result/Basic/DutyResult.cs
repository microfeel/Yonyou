using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DutyResult : ApiResult
    {
        public Duty Duty { get; set; }
    }
    public class DutyListResult : DbListResult<Duty>
    {
        [JsonPropertyName("duty")]
        public override List<Duty> List { get; set; }
    }
}

