using System;
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