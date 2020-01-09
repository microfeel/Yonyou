using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class ReceivesendtypeResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("receivesendtype")]
        public Receivesendtype Receivesendtype { get; set; }
    }
    public class ReceivesendtypeListResult : DbListResult<Receivesendtype>
    {
        [JsonPropertyName("receivesendtype")]
        public override List<Receivesendtype> List { get; set; }
    }
}

