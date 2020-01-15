using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class InventoryclassResult : ApiResult
    {
        public Inventoryclass Inventoryclass { get; set; }
    }
    public class InventoryclassListResult : DbListResult<Inventoryclass>
    {
        [JsonPropertyName("inventoryclass")]
        public override List<Inventoryclass> List { get; set; }
    }
}

