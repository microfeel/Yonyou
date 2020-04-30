using MicroFeel.Yonyou.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;

namespace MicroFeel.Yonyou.Api.Test
{
    [TestClass]
    public class ApiTest
    {
        public const string appkey = "opaddd40e399ef4e98a";
        public const string appSecret = "ee5e0ee78c5942ef91686b61d2b76239";
        public const string from_account = "microfeel";
        public const string to_account = "18926990017";
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
        [TestMethod]
        public void MyTestMethod()
        {
            var service = new Finance.Financial(new Finance.FinancialOptions()
            {
                FinancialType = Finance.FinancialType.YongYouU8,
                FinancialDbConnectionString = "server=.;user id=sa;password=1989210liuyu;database=UFDATA_001_2019;"
            });
            Assert.IsNotNull(service.Service);
        }

    }
}
