using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Request
{
    public class BillRequest : CallerRequest
    {
        [JsonPropertyName("tradeid")]
        public string TradeId { get; set; }

        [JsonPropertyName("ds_sequence")]
        public int DsSequence { get; set; }

        [JsonPropertyName("sync")]
        public int Sync { get; set; } = 1;

        public override string ToString()
        {
            return $"{base.ToString()}&tradeid={TradeId}&ds_sequence={DsSequence}&sync={Sync}";
        }
    } 
}
