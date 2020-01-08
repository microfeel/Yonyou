using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
                        
namespace MicroFeel.Yonyou.Api.Model.Result
{                             
public class CodeschemeResult : Codescheme, IApiResult
{
[JsonPropertyName("errcode")]
public string Errcode { get; set; }
[JsonPropertyName("errmsg")]
public string Errmsg { get; set; }
}
public class CodeschemeListResult : DbListResult<Codescheme>
{
[JsonPropertyName("codescheme")]
public override List<Codescheme> List { get; set; }
}
}

