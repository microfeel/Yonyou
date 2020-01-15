using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class WarehouseResult : ApiResult
    {
        public Warehouse Warehouse { get; set; }
    }

    public class WarehouseListResult : DbListResult<Warehouse>
    {
        [JsonPropertyName("warehouse")]
        public override List<Warehouse> List { get; set; }
    }

}