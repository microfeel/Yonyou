using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
                        
namespace MicroFeel.Yonyou.Api.Model.Result
{                             
public class CodeResult : Code, IApiResult
{
[JsonPropertyName("errcode")]
public string Errcode { get; set; }
[JsonPropertyName("errmsg")]
public string Errmsg { get; set; }
}
public class CodeListResult : DbListResult<Code>
{
[JsonPropertyName("code")]
public override List<Code> List { get; set; }
}
}

