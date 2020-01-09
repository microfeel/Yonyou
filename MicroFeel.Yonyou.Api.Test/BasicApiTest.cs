using MicroFeel.Yonyou.Api.Model.Result;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Web;

namespace MicroFeel.Yonyou.Api.Test
{
    [TestClass]
    public class BasicApiTest : ApiTest
    {
        BasicApi api = new BasicApi();
        public BasicApiTest()
        {
            api.Init(base_url, appkey, appSecret, from_account, to_account);
        }

        #region U8账套
        [TestMethod]
        public async Task Batch_Get_Account()
        {
            var result = await api.Batch_Get_AccountAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Account()
        {
            var id = "999";
            var result = await api.Get_AccountAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 交易分类
        [TestMethod]
        public async Task Batch_Get_Payunitclass()
        {
            var result = await api.Batch_Get_PayunitclassAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Payunitclass()
        {
            var id = "03";
            var result = await api.Get_PayunitclassAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 交易单位【{"errcode":"20002","errmsg":"未检索到匹配的[交易单位]。"}】
        [TestMethod]
        public async Task Batch_Get_Payunit()
        {
            var result = await api.Batch_Get_PayunitAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Payunit()
        {
            var id = "999";
            var result = await api.Get_PayunitAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 人员【未返回openbank对象】
        [TestMethod]
        public async Task Batch_Get_Person()
        {
            var result = await api.Batch_Get_PersonAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Person()
        {
            var id = "BG637";
            var result = await api.Get_PersonAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 人员类别
        [TestMethod]
        public async Task Batch_Get_Persontype()
        {
            var result = await api.Batch_Get_PersontypeAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Persontype()
        {
            var id = "101";
            var result = await api.Get_PersontypeAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 仓库
        [TestMethod]
        public async Task Batch_Get_Warehouse()
        {
            var result = await api.Batch_Get_WarehouseAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Warehouse()
        {
            var id = "1002";
            var result = await api.Get_WarehouseAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 会计期间
        [TestMethod]
        public async Task Batch_Get_Period()
        {
            var result = await api.Batch_Get_PeriodAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 供应商
        [TestMethod]
        public async Task Batch_Get_Vendor()
        {
            var result = await api.Batch_Get_VendorAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Vendor()
        {
            var id = "010104";
            var result = await api.Get_VendorAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 供应商分类
        [TestMethod]
        public async Task Batch_Get_Vendorclass()
        {
            var result = await api.Batch_Get_VendorclassAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Vendorclass()
        {
            var id = "0101";
            var result = await api.Get_VendorclassAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 供应商银行【特殊情况】
        [TestMethod]
        public async Task Batch_Get_Vendor_Bank()
        {
            var result = await api.Batch_Get_Vendor_BankAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Vendor_Bank()
        {
            var id = "999";
            var result = await api.Get_Vendor_BankAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 凭证类别
        [TestMethod]
        public async Task Batch_Get_Dsign()
        {
            var result = await api.Batch_Get_DsignAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Dsign()
        {
            var id = "6";
            var result = await api.Get_DsignAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 地区分类
        [TestMethod]
        public async Task Batch_Get_Districtclass()
        {
            var result = await api.Batch_Get_DistrictclassAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Districtclass()
        {
            var id = "11";
            var result = await api.Get_DistrictclassAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        #endregion

        #region 存货分类
        [TestMethod]
        public async Task Batch_Get_Inventoryclass()
        {
            var result = await api.Batch_Get_InventoryclassAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Inventoryclass()
        {
            var id = "11105";
            var result = await api.Get_InventoryclassAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 存货档案
        [TestMethod]
        public async Task Batch_Get_Inventory()
        {
            var result = await api.Batch_Get_InventoryAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Inventory()
        {
            var id = "111010006";
            var result = await api.Get_InventoryAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 客户
        [TestMethod]
        public async Task Batch_Get_Customer()
        {
            var result = await api.Batch_Get_CustomerAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Customer()
        {
            var id = "102011";
            var result = await api.Get_CustomerAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 客户分类
        [TestMethod]
        public async Task Batch_Get_Customerclass()
        {
            var result = await api.Batch_Get_CustomerclassAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Customerclass()
        {
            var id = "103";
            var result = await api.Get_CustomerclassAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 客户地址
        [TestMethod]
        public async Task Batch_Get_Customeraddress()
        {
            var result = await api.Batch_Get_CustomeraddressAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Customeraddress()
        {
            var id = "276002";
            var result = await api.Get_CustomeraddressAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 客户联系人
        [TestMethod]
        public async Task Batch_Get_Customercontacts()
        {
            var result = await api.Batch_Get_CustomercontactsAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Customercontacts()
        {
            var id = "00000018";
            var result = await api.Get_CustomercontactsAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 客户银行【特使情况】
        [TestMethod]
        public async Task Batch_Get_Customer_bank()
        {
            var result = await api.Batch_Get_Customer_BankAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Customer_bank()
        {
            var id = "999";
            var result = await api.Get_Customer_BankAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 币种
        [TestMethod]
        public async Task Batch_Get_Currency()
        {
            var result = await api.Batch_Get_CurrencyAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Currency()
        {
            var id = "RMB";
            var result = await api.Get_CurrencyAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 常用摘要【(20002)未检索到匹配的[常用摘要]】
        [TestMethod]
        public async Task Batch_Get_Digest()
        {
            var result = await api.Batch_Get_DigestAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Digest()
        {
            var id = "999";
            var result = await api.Get_DigestAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 收付款协议档案【(20002)未检索到匹配的[收付款协议档案]】
        [TestMethod]
        public async Task Batch_Get_Agreement()
        {
            var result = await api.Batch_Get_AgreementAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Agreement()
        {
            var id = "999";
            var result = await api.Get_AgreementAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 收发类别
        [TestMethod]
        public async Task Batch_Get_Receivesendtype()
        {
            var result = await api.Batch_Get_ReceivesendtypeAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Receivesendtype()
        {
            var id = "102";
            var result = await api.Get_ReceivesendtypeAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 本单位开户银行【(20002)未检索到匹配的[本单位开户银行]】
        [TestMethod]
        public async Task Batch_Get_Accountingbank()
        {
            var result = await api.Batch_Get_AccountingbankAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Accountingbank()
        {
            var id = "999";
            var result = await api.Get_AccountingbankAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 汇率【(20002)未检索到匹配的[汇率]】
        [TestMethod]
        public async Task Batch_Get_Exchangerate()
        {
            var result = await api.Batch_Get_ExchangerateAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Exchangerate()
        {
            var id = "999";
            var result = await api.Get_ExchangerateAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 现金流量项目
        [TestMethod]
        public async Task Batch_Get_Cashflowitem()
        {
            var result = await api.Batch_Get_CashflowitemAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Cashflowitem()
        {
            var id = "03";
            var result = await api.Get_CashflowitemAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 科目【查单条返回的是code值一样的数组】
        [TestMethod]
        public async Task Batch_Get_Code()
        {
            var result = await api.Batch_Get_CodeAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Code()
        {
            var id = "122101";
            var result = await api.Get_CodeAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 结算方式
        [TestMethod]
        public async Task Batch_Get_Settlestyle()
        {
            var result = await api.Batch_Get_SettlestyleAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Settlestyle()
        {
            var id = "1";
            var result = await api.Get_SettlestyleAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 编码方案
        [TestMethod]
        public async Task Batch_Get_Codescheme()
        {
            var result = await api.Batch_Get_CodeschemeAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Codescheme()
        {
            var id = "rd_style";
            var result = await api.Get_CodeschemeAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 职位档案
        [TestMethod]
        public async Task Batch_Get_Job()
        {
            var result = await api.Batch_Get_JobAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Job()
        {
            var id = "001";
            var result = await api.Get_JobAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 职务档案
        [TestMethod]
        public async Task Batch_Get_Duty()
        {
            var result = await api.Batch_Get_DutyAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Duty()
        {
            var id = "001";
            var result = await api.Get_DutyAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 职务类别
        [TestMethod]
        public async Task Batch_Get_Dutytype()
        {
            var result = await api.Batch_Get_DutytypeAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Dutytype()
        {
            var id = "7";
            var result = await api.Get_DutytypeAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 自定义项档案
        [TestMethod]
        public async Task Batch_Get_Define()
        {
            var result = await api.Batch_Get_DefineAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 自由项【(20002)未检索到匹配的[自由项]】
        [TestMethod]
        public async Task Batch_Get_Freearch()
        {
            var result = await api.Batch_Get_FreearchAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Freearch()
        {
            var id = "999";
            var result = await api.Get_FreearchAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 计量单位
        [TestMethod]
        public async Task Batch_Get_Unit()
        {
            var result = await api.Batch_Get_UnitAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Unit()
        {
            var id = "0301";
            var result = await api.Get_UnitAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 费用项目【(20002)未检索到匹配的[费用项目]】
        [TestMethod]
        public async Task Batch_Get_Expenseitem()
        {
            var result = await api.Batch_Get_ExpenseitemAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Expenseitem()
        {
            var id = "999";
            var result = await api.Get_ExpenseitemAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 费用项目分类【(20002)未检索到匹配的[费用项目分类]】
        [TestMethod]
        public async Task Batch_Get_Expitemclass()
        {
            var result = await api.Batch_Get_ExpitemclassAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Expitemclass()
        {
            var id = "999";
            var result = await api.Get_ExpitemclassAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 部门
        [TestMethod]
        public async Task Batch_Get_Department()
        {
            var result = await api.Batch_Get_DepartmentAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Department()
        {
            var id = "0901";
            var result = await api.Get_DepartmentAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 银行
        [TestMethod]
        public async Task Batch_Get_Bank()
        {
            var result = await api.Batch_Get_BankAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Bank()
        {
            var id = "00005";
            var result = await api.Get_BankAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 销售类型
        [TestMethod]
        public async Task Batch_Get_Saletype()
        {
            var result = await api.Batch_Get_SaletypeAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Saletype()
        {
            var id = "02";
            var result = await api.Get_SaletypeAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        //测试到这里↓↓↓

        #region 项目
        [TestMethod]
        public async Task Batch_Get_Fitem()
        {
            var result = await api.Batch_Get_FitemAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 项目分类
        [TestMethod]
        public async Task Batch_Get_Fitemclass()
        {
            var result = await api.Batch_Get_FitemclassAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 项目大类
        [TestMethod]
        public async Task Batch_Get_Fitemcategory()
        {
            var result = await api.Batch_Get_FitemcategoryAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Fitemcategory()
        {
            var id = "999";
            var result = await api.Get_FitemcategoryAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        #region 预算口径
        [TestMethod]
        public async Task Batch_Get_Budgetcaliber()
        {
            var result = await api.Batch_Get_BudgetcaliberAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }

        [TestMethod]
        public async Task Get_Budgetcaliber()
        {
            var id = "999";
            var result = await api.Get_BudgetcaliberAsync(id);
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine($"{json}");
        }
        #endregion

        [TestMethod]
        public void aa()
        {
            var bb = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Fitem>>("[{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":23,\"citemcode\":\"01\",\"citemname\":\"销售商品、提供劳务收到的现金\",\"bclose\":false,\"citemccode\":\"0101\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":24,\"citemcode\":\"02\",\"citemname\":\"收到的税费返还\",\"bclose\":false,\"citemccode\":\"0101\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":25,\"citemcode\":\"03\",\"citemname\":\"收到的其他与经营活动的现金\",\"bclose\":false,\"citemccode\":\"0101\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":26,\"citemcode\":\"04\",\"citemname\":\"购买商品、接受劳务支付的现金\",\"bclose\":false,\"citemccode\":\"0102\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":27,\"citemcode\":\"05\",\"citemname\":\"支付给职工以及为职工支付的现金\",\"bclose\":false,\"citemccode\":\"0102\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":28,\"citemcode\":\"06\",\"citemname\":\"支付的各项税费\",\"bclose\":false,\"citemccode\":\"0102\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":29,\"citemcode\":\"07\",\"citemname\":\"支付的与其他经营活动有关的现金\",\"bclose\":false,\"citemccode\":\"0102\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":30,\"citemcode\":\"08\",\"citemname\":\"收回投资所收到的现金\",\"bclose\":false,\"citemccode\":\"0201\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":31,\"citemcode\":\"09\",\"citemname\":\"取得投资收益所收到的现金\",\"bclose\":false,\"citemccode\":\"0201\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":32,\"citemcode\":10,\"citemname\":\"处置固定资产、无形资产和其他长期资产所收回的现金净额\",\"bclose\":false,\"citemccode\":\"0201\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":33,\"citemcode\":11,\"citemname\":\"处置子公司及其他营业单位收到的现金净额\",\"bclose\":false,\"citemccode\":\"0201\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":34,\"citemcode\":12,\"citemname\":\"收到的其他与投资活动有关的现金\",\"bclose\":false,\"citemccode\":\"0201\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":35,\"citemcode\":13,\"citemname\":\"购建固定资产、无形资产和其他长期资产所支付的现金\",\"bclose\":false,\"citemccode\":\"0202\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":36,\"citemcode\":14,\"citemname\":\"投资所支付的现金\",\"bclose\":false,\"citemccode\":\"0202\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":37,\"citemcode\":15,\"citemname\":\"取得子公司及其他营业单位支付的现金净额\",\"bclose\":false,\"citemccode\":\"0202\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":38,\"citemcode\":16,\"citemname\":\"支付的其他与投资活动有关的现金\",\"bclose\":false,\"citemccode\":\"0202\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":39,\"citemcode\":17,\"citemname\":\"吸收投资所收到的现金\",\"bclose\":false,\"citemccode\":\"0301\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":40,\"citemcode\":18,\"citemname\":\"借款所收到的现金\",\"bclose\":false,\"citemccode\":\"0301\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":41,\"citemcode\":19,\"citemname\":\"收到的其他与筹资活动有关的现金\",\"bclose\":false,\"citemccode\":\"0301\",\"cdirection\":\"流入\",\"citemcname\":\"现金流入\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":42,\"citemcode\":20,\"citemname\":\"偿还债务所支付的现金\",\"bclose\":false,\"citemccode\":\"0302\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":43,\"citemcode\":21,\"citemname\":\"分配股利、利润或偿还利息所支付的现金\",\"bclose\":false,\"citemccode\":\"0302\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":44,\"citemcode\":22,\"citemname\":\"支付的其他与筹资活动有关的现金\",\"bclose\":false,\"citemccode\":\"0302\",\"cdirection\":\"流出\",\"citemcname\":\"现金流出\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":45,\"citemcode\":23,\"citemname\":\"汇率变动对现金的影响\",\"bclose\":false,\"citemccode\":\"0401\",\"cdirection\":\"流入\",\"citemcname\":\"汇率变动\"},{\"citem_class\":98,\"citem_name\":\"现金流量项目\",\"i_id\":46,\"citemcode\":24,\"citemname\":\"现金及现金等价物净增加额\",\"bclose\":false,\"citemccode\":\"0501\",\"cdirection\":\"流入\",\"citemcname\":\"现金及现金等价物\"},{\"citem_class\":97,\"citem_name\":\"项目管理\",\"i_id\":1,\"citemcode\":\"01\",\"citemname\":\"柏瑞美\",\"bclose\":false,\"citemccode\":1,\"citemcname\":\"品牌\"},{\"citem_class\":97,\"citem_name\":\"项目管理\",\"i_id\":2,\"citemcode\":\"02\",\"citemname\":\"高柏诗\",\"bclose\":false,\"citemccode\":1,\"citemcname\":\"品牌\"},{\"citem_class\":97,\"citem_name\":\"项目管理\",\"i_id\":3,\"citemcode\":\"03\",\"citemname\":\"米约\",\"bclose\":false,\"citemccode\":1,\"citemcname\":\"品牌\"},{\"citem_class\":97,\"citem_name\":\"项目管理\",\"i_id\":4,\"citemcode\":\"04\",\"citemname\":\"车间\",\"bclose\":false,\"citemccode\":1,\"citemcname\":\"品牌\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":1,\"citemcode\":\"01\",\"citemname\":\"应收款项、预收账款确认的收入\",\"bclose\":false,\"citemccode\":101,\"cdirection\":\"贷\",\"citemcname\":\"当期确认为收入但没有确认为预算收入\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":2,\"citemcode\":\"02\",\"citemname\":\"接受非货币性资产捐赠确认的收入\",\"bclose\":false,\"citemccode\":101,\"cdirection\":\"贷\",\"citemcname\":\"当期确认为收入但没有确认为预算收入\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":3,\"citemcode\":\"03\",\"citemname\":\"支付应付款项、预付账款的支出\",\"bclose\":false,\"citemccode\":102,\"cdirection\":\"借\",\"citemcname\":\"当期确认为预算支出但没有确认为费用\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":4,\"citemcode\":\"04\",\"citemname\":\"为取得存货、政府储备物资等计入物资成本的支出\",\"bclose\":false,\"citemccode\":102,\"cdirection\":\"借\",\"citemcname\":\"当期确认为预算支出但没有确认为费用\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":5,\"citemcode\":\"05\",\"citemname\":\"为购建固定资产等的资本性支出\",\"bclose\":false,\"citemccode\":102,\"cdirection\":\"借\",\"citemcname\":\"当期确认为预算支出但没有确认为费用\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":6,\"citemcode\":\"06\",\"citemname\":\"偿还借款本息支出\",\"bclose\":false,\"citemccode\":102,\"cdirection\":\"借\",\"citemcname\":\"当期确认为预算支出但没有确认为费用\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":7,\"citemcode\":\"07\",\"citemname\":\"收到应收款项、预收账款确认的预算收入\",\"bclose\":false,\"citemccode\":201,\"cdirection\":\"贷\",\"citemcname\":\"当期确认为预算收入但没有确认为收入\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":8,\"citemcode\":\"08\",\"citemname\":\"取得借款确认的预算收入\",\"bclose\":false,\"citemccode\":201,\"cdirection\":\"贷\",\"citemcname\":\"当期确认为预算收入但没有确认为收入\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":9,\"citemcode\":\"09\",\"citemname\":\"发出存货、政府储备物资等确认的费用\",\"bclose\":false,\"citemccode\":202,\"cdirection\":\"借\",\"citemcname\":\"当期确认为费用但没有确认为预算支出\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":10,\"citemcode\":10,\"citemname\":\"计提的折旧费用和摊销费用\",\"bclose\":false,\"citemccode\":202,\"cdirection\":\"借\",\"citemcname\":\"当期确认为费用但没有确认为预算支出\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":11,\"citemcode\":11,\"citemname\":\"确认的资产处置费用（处置资产价值）\",\"bclose\":false,\"citemccode\":202,\"cdirection\":\"借\",\"citemcname\":\"当期确认为费用但没有确认为预算支出\"},{\"citem_class\":\"ZF\",\"citem_name\":\"差异分析项目\",\"i_id\":12,\"citemcode\":12,\"citemname\":\"应付款项、预付账款确认的费用\",\"bclose\":false,\"citemccode\":202,\"cdirection\":\"借\",\"citemcname\":\"当期确认为费用但没有确认为预算支出\"}]");
            Console.WriteLine(bb);
        }
    }
}
