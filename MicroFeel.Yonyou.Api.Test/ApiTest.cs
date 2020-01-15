using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;

namespace MicroFeel.Yonyou.Api.Test
{
    public class ApiTest
    {
        public const string appkey = "opaddd40e399ef4e98a";
        public const string appSecret = "ee5e0ee78c5942ef91686b61d2b76239";
        public const string from_account = "microfeel";
        public const string to_account = "test_microfeel";
        public const string base_url = "https://api.yonyouup.com/";
        protected JsonSerializerOptions JsonOptions
        {
            get
            {
                var options = new JsonSerializerOptions();
                options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All);
                return options;
            }
        }
    }
}
