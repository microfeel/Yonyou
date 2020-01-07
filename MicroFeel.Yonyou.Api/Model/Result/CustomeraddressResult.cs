using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
                        
namespace MicroFeel.Yonyou.Api.Model.Result
{                             
public class CustomeraddressResult : Customeraddress, IApiResult
{
[JsonPropertyName("errcode")]
public string Errcode { get; set; }
[JsonPropertyName("errmsg")]
public string Errmsg { get; set; }
}
public class CustomeraddressListResult : DbListResult<Customeraddress>
{
[JsonPropertyName("customeraddress")]
public override List<Customeraddress> List { get; set; }
}
}

