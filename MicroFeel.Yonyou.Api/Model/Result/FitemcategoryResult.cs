using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class FitemcategoryResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("fitemcategory")]
        public Fitemcategory Fitemcategory { get; set; }
    }
    public class FitemcategoryListResult : DbListResult<Fitemcategory>
    {
        [JsonPropertyName("fitemcategory")]
        public override List<Fitemcategory> List { get; set; }
    }
}

