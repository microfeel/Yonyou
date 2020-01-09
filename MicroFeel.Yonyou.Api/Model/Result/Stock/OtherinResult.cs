using System;
    public class OtherinResult : Otherin, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class OtherinListResult : DbListResult<Otherin>, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
        [JsonPropertyName("otherinlist")]
        public override List<Otherin> List { get; set; }
    }
}