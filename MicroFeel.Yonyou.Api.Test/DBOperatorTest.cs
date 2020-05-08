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
            service = new YongYouService("server=.;user id=sa;password=1989210liuyu;database=UFDATA_001_2019;");
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
                            StoreId = ""
                   }
                }
            });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MyTestMethod1()
        {
            var result = service.FromPuArrivalVouchToStoreRecord("DH2002290001");
            Assert.IsTrue(result);
        }
    }
}
