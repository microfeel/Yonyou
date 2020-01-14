using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{	public class SaleorderResult:Saleorder,IApiResult	{[JsonPropertyName("errcode")]
                     public string Errcode { get; set; }
                     [JsonPropertyName("errmsg")]
                     public string Errmsg { get; set; }	}	public class SaleorderListResult: DbListResult<Saleorder>	{[JsonPropertyName("saleorderlist")]public override List<Saleorder> List { get; set; }	}	}