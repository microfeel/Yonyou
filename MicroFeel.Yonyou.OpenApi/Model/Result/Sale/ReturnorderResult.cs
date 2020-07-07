using System;
    public class ReturnorderResult : ApiResult
    {
        public Returnorder Returnorder { get; set; }
    }

    public class ReturnorderListResult : DbListResult<Returnorder>
    {
        [JsonPropertyName("returnorderlist")]
        public override List<Returnorder> List { get; set; }
    }
}