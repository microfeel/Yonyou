using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{	public class ReturnorderResult:Returnorder,IApiResult	{[JsonPropertyName("errcode")]
                     public string Errcode { get; set; }
                     [JsonPropertyName("errmsg")]
                     public string Errmsg { get; set; }	}	public class ReturnorderListResult: DbListResult<Returnorder>	{[JsonPropertyName("returnorderlist")]public override List<Returnorder> List { get; set; }	}	}