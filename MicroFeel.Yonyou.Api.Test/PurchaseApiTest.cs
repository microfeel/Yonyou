using MicroFeel.Yonyou.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Api.Test
{
    [TestClass]
    public class PurchaseApiTest : ApiTest
    {
        [TestMethod]
        public async Task AddPurchaseorderAsync()
        {
            var api = new PurchaseApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Add_PurchaseorderAsync(new Purchaseorder()
            {
                Code = "1234",
                CurrencyRate = 1,
                Date = DateTime.Now,
                Define8 = "柏瑞美",
                Deptcode = "04",
                Maker = "测试",
               // OperationTypeCode = "102",
                Personcode = "",
               // PurchaseTypeCode = "102",
                State = "0",
                Vendorabbname = "珠海祥茂辉",
                Vendorcode = "010105",
                Vendorname = "珠海祥茂辉",
                PurchaseorderEntry = new List<PurchaseorderEntry>()
                {
                 new PurchaseorderEntry()
                            {
                                Arrivedate = DateTime.Now.AddDays(30),
                                Assistantunit = "支",
                                Discount = 1,
                                Inventorycode = "131010018",
                                Quantity = 1,
                                Price = 12.1f,
                                Inventoryname = "轻盈感光隔离霜（金色）支盒",
                                Inventorystd = "JGNT24"
                            }
                }
            });

            Assert.IsNotNull(result);
            var jsonResult = System.Text.Json.JsonSerializer.Serialize(result, JsonOptions);

            System.Console.WriteLine($"Purchaseorder is :{jsonResult}");
        }

        [TestMethod]
        public async Task BatchGetPurchaseorderAsync()
        {
            var api = new PurchaseApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Batch_Get_PurchaseorderlistAsync();
            Console.WriteLine(result.Count);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public async Task GetPurchaseorderAsync()
        {
            var api = new PurchaseApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Get_PurchaseorderAsync("PRPO20191230327");
            var jsonResult = System.Text.Json.JsonSerializer.Serialize(result, JsonOptions);
            Console.WriteLine(jsonResult);
            Assert.IsNotNull(jsonResult);
        }

        [TestMethod]
        public void Json()
        {
            var s = "{\"page_index\":\"1\",\"page_count\":\"33\",\"row_count\":\"642\",\"rows_per_page\":\"20\",\"errmsg\":\"\",\"errcode\":\"0\",\"purchaseorderlist\":[{\"code\":\"PRPO20191230327\",\"date\":\"2019-12-31\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040202\",\"vendorname\":\"中山市益弘包装材料有限公司\",\"vendorabbname\":\"益弘贴标部\",\"maker\":\"邓志娟\",\"verifier\":\"邓志娟\",\"money\":\"494.0000\",\"sum\":\"494.0000\",\"receiptstatus\":\"2\"},{\"code\":\"PRPO20191227327\",\"date\":\"2019-12-27\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"purchase_type_code\":\"03\",\"purchase_type_name\":\"柜台\",\"vendorcode\":\"050501\",\"vendorname\":\"上海富彭\",\"vendorabbname\":\"上海富彭\",\"deptcode\":\"03\",\"deptname\":\"人事行政部\",\"personcode\":\"GA241\",\"personname\":\"杨葆春\",\"maker\":\"杨葆春\",\"verifier\":\"杨葆春\",\"money\":\"197152.0000\",\"sum\":\"197152.0000\",\"receiptstatus\":\"2\"},{\"code\":\"PRPO20191227326\",\"date\":\"2019-12-30\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"050202\",\"vendorname\":\"中山市锐博五金塑料制品有限公司\",\"vendorabbname\":\"锐博\",\"maker\":\"王振宇\",\"verifier\":\"王振宇\",\"money\":\"2340.0000\",\"sum\":\"2340.0000\",\"receiptstatus\":\"0\"},{\"code\":\"PRPO20191224324\",\"date\":\"2019-12-30\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040202\",\"vendorname\":\"中山市益弘包装材料有限公司\",\"vendorabbname\":\"益弘贴标部\",\"maker\":\"邓志娟\",\"verifier\":\"邓志娟\",\"money\":\"108.0000\",\"sum\":\"108.0000\",\"receiptstatus\":\"2\"},{\"code\":\"PRPO20191223323\",\"date\":\"2019-12-31\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"purchase_type_code\":\"03\",\"purchase_type_name\":\"柜台\",\"vendorcode\":\"050501\",\"vendorname\":\"上海富彭\",\"vendorabbname\":\"上海富彭\",\"deptcode\":\"03\",\"deptname\":\"人事行政部\",\"personcode\":\"GA241\",\"personname\":\"杨葆春\",\"maker\":\"杨葆春\",\"verifier\":\"杨葆春\",\"money\":\"800.0000\",\"sum\":\"800.0000\",\"receiptstatus\":\"0\"},{\"code\":\"PRPO20191222193\",\"date\":\"2019-12-23\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040103\",\"vendorname\":\"珠海创艺印刷有限公司（纸箱部）\",\"vendorabbname\":\"创艺纸箱部\",\"maker\":\"邓志娟\",\"verifier\":\"邓志娟\",\"money\":\"438.2000\",\"sum\":\"438.2000\",\"receiptstatus\":\"0\"},{\"code\":\"PRPO20191221323\",\"date\":\"2019-12-16\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"purchase_type_code\":\"03\",\"purchase_type_name\":\"柜台\",\"vendorcode\":\"050501\",\"vendorname\":\"上海富彭\",\"vendorabbname\":\"上海富彭\",\"deptcode\":\"03\",\"deptname\":\"人事行政部\",\"personcode\":\"GA241\",\"personname\":\"杨葆春\",\"maker\":\"杨葆春\",\"verifier\":\"杨葆春\",\"money\":\"175111.0000\",\"sum\":\"175111.0000\",\"receiptstatus\":\"0\"},{\"code\":\"PRPO20191221322\",\"date\":\"2019-12-23\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040102\",\"vendorname\":\"珠海创艺印刷有限公司（标贴部）\",\"vendorabbname\":\"创艺标贴部\",\"maker\":\"邓志娟\",\"verifier\":\"邓志娟\",\"money\":\"0.0000\",\"sum\":\"0.0000\",\"receiptstatus\":\"2\"},{\"code\":\"PRPO20191220321\",\"date\":\"2019-12-23\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040103\",\"vendorname\":\"珠海创艺印刷有限公司（纸箱部）\",\"vendorabbname\":\"创艺纸箱部\",\"maker\":\"邓志娟\",\"verifier\":\"邓志娟\",\"money\":\"900.0000\",\"sum\":\"900.0000\",\"receiptstatus\":\"2\"},{\"code\":\"PRPO20191219321\",\"date\":\"2019-12-31\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"purchase_type_code\":\"03\",\"purchase_type_name\":\"柜台\",\"vendorcode\":\"050501\",\"vendorname\":\"上海富彭\",\"vendorabbname\":\"上海富彭\",\"deptcode\":\"03\",\"deptname\":\"人事行政部\",\"personcode\":\"GA241\",\"personname\":\"杨葆春\",\"maker\":\"杨葆春\",\"verifier\":\"杨葆春\",\"money\":\"391346.0000\",\"sum\":\"391346.0000\",\"receiptstatus\":\"0\"},{\"code\":\"ＰＲＰＯ２０１９１２１９３２０\",\"date\":\"2019-12-01\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040202\",\"vendorname\":\"中山市益弘包装材料有限公司\",\"vendorabbname\":\"益弘贴标部\",\"maker\":\"邓志娟\",\"verifier\":\"邓志娟\",\"money\":\"90.0000\",\"sum\":\"90.0000\",\"receiptstatus\":\"2\"},{\"code\":\"PRPO20191214319\",\"date\":\"2019-12-14\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040102\",\"vendorname\":\"珠海创艺印刷有限公司（标贴部）\",\"vendorabbname\":\"创艺标贴部\",\"maker\":\"张惠明\",\"verifier\":\"demo\",\"money\":\"16440.0000\",\"sum\":\"16440.0000\",\"receiptstatus\":\"1\"},{\"code\":\"PRPO20191213318\",\"date\":\"2019-12-13\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040202\",\"vendorname\":\"中山市益弘包装材料有限公司\",\"vendorabbname\":\"益弘贴标部\",\"maker\":\"张惠明\",\"verifier\":\"demo\",\"money\":\"8.0000\",\"sum\":\"8.0000\",\"receiptstatus\":\"1\"},{\"code\":\"PRPO20191212317\",\"date\":\"2019-12-12\",\"operation_type_code\":\"普通采购\",\"state\":\"关闭\",\"vendorcode\":\"051801\",\"vendorname\":\"四会市金利达包装有限公司\",\"vendorabbname\":\"四会金利达\",\"maker\":\"张惠明\",\"verifier\":\"demo\",\"closer\":\"肖润英\",\"money\":\"3300.0000\",\"sum\":\"3300.0000\",\"receiptstatus\":\"1\"},{\"code\":\"PRPO20191212316\",\"date\":\"2019-12-12\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040203\",\"vendorname\":\"中山市益弘包装材料有限公司（纸箱部）\",\"vendorabbname\":\"益弘纸箱部\",\"maker\":\"张惠明\",\"verifier\":\"demo\",\"money\":\"1400.0000\",\"sum\":\"1400.0000\",\"receiptstatus\":\"0\"},{\"code\":\"PRPO20191210316\",\"date\":\"2019-12-10\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"030301\",\"vendorname\":\"宁波市海曙汇和日化包装厂\",\"vendorabbname\":\"汇和\",\"maker\":\"张惠明\",\"verifier\":\"张惠明\",\"money\":\"1250.0000\",\"sum\":\"1250.0000\",\"receiptstatus\":\"2\"},{\"code\":\"PRPO20191209315\",\"date\":\"2019-12-09\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"020202\",\"vendorname\":\"中山天达包装材料有限公司\",\"vendorabbname\":\"中山天达\",\"maker\":\"张惠明\",\"verifier\":\"邓志娟\",\"money\":\"2255.0000\",\"sum\":\"2255.0000\",\"receiptstatus\":\"0\"},{\"code\":\"PRPO20191209314\",\"date\":\"2019-12-09\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"041101\",\"vendorname\":\"广州比盛印刷有限公司\",\"vendorabbname\":\"比盛\",\"maker\":\"张惠明\",\"verifier\":\"demo\",\"money\":\"1500.0000\",\"sum\":\"1500.0000\",\"receiptstatus\":\"2\"},{\"code\":\"PRPO20191209313\",\"date\":\"2019-12-09\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040105\",\"vendorname\":\"珠海中远包装印刷有限公司\",\"vendorabbname\":\"中远\",\"maker\":\"张惠明\",\"verifier\":\"demo\",\"money\":\"27680.0000\",\"sum\":\"27680.0000\",\"receiptstatus\":\"0\"},{\"code\":\"PRPO20191209311\",\"date\":\"2019-12-09\",\"operation_type_code\":\"普通采购\",\"state\":\"审核\",\"vendorcode\":\"040202\",\"vendorname\":\"中山市益弘包装材料有限公司\",\"vendorabbname\":\"益弘贴标部\",\"maker\":\"张惠明\",\"verifier\":\"张惠明\",\"money\":\"699.0000\",\"sum\":\"699.0000\",\"receiptstatus\":\"1\"}]}";
            var json = System.Text.Json.JsonSerializer.Deserialize<MicroFeel.Yonyou.Api.PurchaseorderListResult>(s);
            Assert.IsNotNull(json.Errcode);
        }
    }
}
