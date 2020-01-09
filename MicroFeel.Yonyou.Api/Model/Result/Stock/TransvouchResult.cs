using System;
    public class TransvouchResult : Transvouch, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class TransvouchListResult : DbListResult<Transvouch>, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
        [JsonPropertyName("transvouchlist")]
        public override List<Transvouch> List { get; set; }
    }
}