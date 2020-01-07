using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class InventoryclassResult : Inventoryclass, IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
    }
    public class InventoryclassListResult : DbListResult<Inventoryclass>
    {
        [JsonPropertyName("inventoryclass")]
        public override List<Inventoryclass> List { get; set; }
    }
}

