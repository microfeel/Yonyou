using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class InventoryResult : Inventory, IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
    }
    public class InventoryListResult : DbListResult<Inventory>
    {
        [JsonPropertyName("inventory")]
        public override List<Inventory> List { get; set; }
    }
}

