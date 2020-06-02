

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{

    public class Voucherlist
    {
        [JsonPropertyName("entry")]
        public IEnumerable<Voucher> Vouchers { get; set; }
    }

}
