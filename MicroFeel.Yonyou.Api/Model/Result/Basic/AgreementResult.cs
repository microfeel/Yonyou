using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class AgreementResult : ApiResult
    {
    }
    public class AgreementListResult : DbListResult<Agreement>
    {
        [JsonPropertyName("agreement")]
        public override List<Agreement> List { get; set; }
    }
}

