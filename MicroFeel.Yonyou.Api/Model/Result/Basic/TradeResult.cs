﻿using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class TradeResult : ApiResult
    {
        [JsonPropertyName("trade")]
        public Trade Trade { get; set; }
    }

}
