using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DepartmentResult : ApiResult
    {
        public Department Department { get; set; }
    }
    public class DepartmentListResult : DbListResult<Department>
    {
        [JsonPropertyName("department")]
        public override List<Department> List { get; set; }
    }
}

