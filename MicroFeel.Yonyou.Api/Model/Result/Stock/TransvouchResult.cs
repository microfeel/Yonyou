using System;
using System.Collections.Generic;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class TransvouchResult : ApiResult
    {
        public Transvouch Transvouch { get; set; }
    }

    public class TransvouchListResult : DbListResult<Transvouch>
    {
       
        [JsonPropertyName("transvouchlist")]
        public override List<Transvouch> List { get; set; }
    }
}
