using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{
    public class OtherinResult : Otherin, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class OtherinListResult : DbListResult<Otherin>
    {
       
        [JsonPropertyName("otherinlist")]
        public override List<Otherin> List { get; set; }
    }
}