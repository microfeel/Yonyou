using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{	public class SaleinvoiceResult:Saleinvoice,IApiResult	{[JsonPropertyName("errcode")]
                     public string Errcode { get; set; }
                     [JsonPropertyName("errmsg")]
                     public string Errmsg { get; set; }	}	public class SaleinvoiceListResult: DbListResult<Saleinvoice>	{[JsonPropertyName("saleinvoicelist")]public override List<Saleinvoice> List { get; set; }	}	}