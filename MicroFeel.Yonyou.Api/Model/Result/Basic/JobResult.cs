using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class JobResult : ApiResult
    {
        [JsonPropertyName("job")]
        public Job Job { get; set; }
    }
    public class JobListResult : DbListResult<Job>
    {
        [JsonPropertyName("job")]
        public override List<Job> List { get; set; }
    }
}

