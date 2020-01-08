using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class PersontypeResult : Persontype, IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
    }

    public class PersontypeListResult : DbListResult<Persontype>
    {
        [JsonPropertyName("persontype")]
        public override List<Persontype> List { get; set; }
    }
}
