using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class ExpenseitemResult : ApiResult
    {
        public Expenseitem Expenseitem { get; set; }
    }
    public class ExpenseitemListResult : DbListResult<Expenseitem>
    {
        [JsonPropertyName("expenseitem")]
        public override List<Expenseitem> List { get; set; }
    }
}

