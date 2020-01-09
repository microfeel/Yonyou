using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class AccountResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("account")]
        public Account Account { get; set; }
    }
    public class AccountListResult : DbListResult<Account>
    {
        [JsonPropertyName("account")]
        public override List<Account> List { get; set; }
    }
}

