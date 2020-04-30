using MicroFeel.Yonyou.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Api.Test
{
    [TestClass]
    public class DBOperatorTest
    {
        YongYouService service;
        public DBOperatorTest()
        {
            service = new YongYouService("server=192.168.12.19;user id=sa;password=123.com;database=UFDATA_999_2019;");
        }

        [TestMethod]
        public void MyTestMethod()
        { 
            var result = service.AddPuarrivalVouch(new Finance.Models.DbDto.DtoStockOrder()
            {
                Brand = "柏瑞美",
                SourceOrderNo = "WD2004260008",
                StoreStockDetail = new List<Finance.Models.DbDto.DtoStockOrder.DtoStoreStockDetail>()
                {
                   new Finance.Models.DbDto.DtoStockOrder.DtoStoreStockDetail()
                   {
                        Numbers = 11,
                         ProductBatch = "aaa",
                          ProductNumbers = "311010016",
                           SourceEntryId = 1,
                            StoreId = 1010
                   }
                }
            });

            Assert.IsTrue(result);
        }
    }
}
