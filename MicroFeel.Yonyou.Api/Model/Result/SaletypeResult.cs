using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class SaletypeResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("saletype")]
        public Saletype Saletype { get; set; }
    }
    public class SaletypeListResult : DbListResult<Saletype>
    {
        [JsonPropertyName("saletype")]
        public override List<Saletype> List { get; set; }
    }
}

