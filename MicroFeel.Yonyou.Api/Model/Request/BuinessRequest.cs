using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Request
{
    public class BuinessRequest : CallerRequest
    {
        [JsonPropertyName("tradeid")]
        public string TradeId { get; set; }

        /// <summary>
        /// 上游id，需要保证biz_id与ERP主键唯一对应关系，tradeid与biz_id只能传入一个
        /// </summary>
        [JsonPropertyName("biz_id")]
        public string BizId { get; set; }

        [JsonPropertyName("ds_sequence")]
        public int DsSequence { get; set; }

        [JsonPropertyName("sync")]
        public int Sync { get; set; } = 1;

        public override string ToString()
        {
            if (string.IsNullOrEmpty(BizId))
                return $"{base.ToString()}&tradeid={TradeId}&ds_sequence={DsSequence}&sync={Sync}";
            return $"{base.ToString()}&biz_id={BizId}&ds_sequence={DsSequence}&sync={Sync}";
        }
    }
}
