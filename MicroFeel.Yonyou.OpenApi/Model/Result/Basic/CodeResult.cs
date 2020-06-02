using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class CodeResult : ApiResult
    {
        [JsonPropertyName("code")]
        public Code Code { get; set; }
    }
    public class CodeListResult : DbListResult<Code>
    {
        [JsonPropertyName("code")]
        public override List<Code> List { get; set; }
    }
}

