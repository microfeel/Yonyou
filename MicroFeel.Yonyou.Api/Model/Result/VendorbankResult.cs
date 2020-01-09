﻿using MicroFeel.Yonyou.Api.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class VendorbankResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
        [JsonPropertyName("vendorbank")]
        public Vendorbank Vendorbank { get; set; }
    }
    public class VendorbankListResult : DbListResult<Vendorbank>
    {
        [JsonPropertyName("vendorbank")]
        public override List<Vendorbank> List { get; set; }
    }
}
