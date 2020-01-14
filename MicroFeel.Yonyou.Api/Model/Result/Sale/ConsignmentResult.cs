using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{	public class ConsignmentResult:Consignment,IApiResult	{[JsonPropertyName("errcode")]
                     public string Errcode { get; set; }
                     [JsonPropertyName("errmsg")]
                     public string Errmsg { get; set; }	}	public class ConsignmentListResult: DbListResult<Consignment>	{[JsonPropertyName("consignmentlist")]public override List<Consignment> List { get; set; }	}	}