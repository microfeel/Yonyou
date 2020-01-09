using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class DepartmentResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("department")]
        public Department Department { get; set; }
    }
    public class DepartmentListResult : DbListResult<Department>
    {
        [JsonPropertyName("department")]
        public override List<Department> List { get; set; }
    }
}

