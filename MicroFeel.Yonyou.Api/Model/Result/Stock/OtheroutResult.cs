using System;
    public class OtheroutResult : Otherout, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
    }

    public class OtheroutListResult : DbListResult<Otherout>, IApiResult
    {
        [JsonPropertyName("errcode")]

        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]

        public string Errmsg { get; set; }
        [JsonPropertyName("otheroutlist")]
        public override List<Otherout> List { get; set; }
    }
}