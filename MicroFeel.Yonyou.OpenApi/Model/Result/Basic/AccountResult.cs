using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class AccountResult : ApiResult
    {
        public Account Account { get; set; }
    }

    public class AccountListResult : DbListResult<Account>
    {
        [JsonPropertyName("account")]
        public override List<Account> List { get; set; }
    }
}

