using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class BudgetcaliberResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("budgetcaliber")]
        public Budgetcaliber Budgetcaliber { get; set; }
    }
    public class BudgetcaliberListResult : DbListResult<Budgetcaliber>
    {
        [JsonPropertyName("budgetcaliber")]
        public override List<Budgetcaliber> List { get; set; }
    }
}

