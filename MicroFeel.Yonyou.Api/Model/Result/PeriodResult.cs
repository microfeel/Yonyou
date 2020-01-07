using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PeriodListResult : DbListResult<Period>
    {
        [JsonPropertyName("period")]
        public override List<Period> List { get; set; }
    }
}
