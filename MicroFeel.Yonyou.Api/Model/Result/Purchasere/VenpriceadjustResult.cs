using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{
    public class VenpriceadjustResult : Venpriceadjust, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class VenpriceadjustListResult : DbListResult<Venpriceadjust>
    {

        [JsonPropertyName("venpriceadjustlist")]
        public override List<Venpriceadjust> List { get; set; }
    }
}