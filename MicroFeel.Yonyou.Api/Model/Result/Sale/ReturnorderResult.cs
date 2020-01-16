using System;using System.Collections.Generic;using MicroFeel.Yonyou.Api.Model.Result;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api.Model.Result{
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