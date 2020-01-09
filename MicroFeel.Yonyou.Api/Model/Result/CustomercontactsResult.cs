using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class CustomercontactsResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("customercontacts")]
        public Customercontacts Customercontacts { get; set; }
    }
    public class CustomercontactsListResult : DbListResult<Customercontacts>
    {
        [JsonPropertyName("customercontacts")]
        public override List<Customercontacts> List { get; set; }
    }
}

