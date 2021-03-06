﻿using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class CodeschemeResult : ApiResult
    {
        public Codescheme Codescheme { get; set; }
    }
    public class CodeschemeListResult : DbListResult<Codescheme>
    {
        [JsonPropertyName("codescheme")]
        public override List<Codescheme> List { get; set; }
    }
}

