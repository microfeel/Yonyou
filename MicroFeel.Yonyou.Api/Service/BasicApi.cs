using MicroFeel.Yonyou.Api.Model.Data;
using MicroFeel.Yonyou.Api.Model.Request;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 基础档案 API  88
    /// </summary>
    public class BasicApi : Api
    {
        public BasicApi() : base("api") { }

        /// <summary>
        /// U8帐套 获取单个U8帐套信息  
        /// </summary> 
        /// <return></return>
        public object get_account() { return null; }
        /// <summary>
        /// 批量获取U8帐套信息  
        /// </summary> 
        /// <return></return>
        public object batch_get_account() { return null; }
        /// <summary>
        /// 交易分类    获取单个交易分类信息 
        /// </summary> 
        /// <return></return>
        public object get_payunitclass() { return null; }
        /// <summary>
        /// 批量获取交易分类信息  
        /// </summary> 
        /// <return></return>
        public object batch_get_payunitclass() { return null; }
        /// <summary>
        /// 交易单位    获取单个交易单位信息 
        /// </summary> 
        /// <return></return>
        public object get_payunit() { return null; }
        /// <summary>
        /// 批量获取交易单位信息  
        /// </summary> 
        /// <return></return>
        public object batch_get_payunit() { return null; }
        /// <summary>
        /// 人员  获取单个人员信息 
        /// </summary> 
        /// <return></return>
        public async Task<PersonResult> Get_PersonAsync(int id, int dsSequence = 1)
        {
            return await GetSync<PersonResult>(id, dsSequence);
        }
        /// <summary>
        /// 修改一个人员  
        /// </summary> 
        /// <return></return>
        public object edit_person() { return null; }
        /// <summary>
        /// 批量获取人员信息    
        /// </summary> 
        /// <return></return>
        public async Task<List<Person>> Batch_Get_PersonAsync(int dsSequence = 1)
        {
            return await GetsSync<PersonListResult, Person>(dsSequence);
        }
        /// <summary>
        /// 添加一个新人员 
        /// </summary> 
        /// <return></return>
        public object add_person() { return null; }
        /// <summary>
        /// 人员类别    获取单个人员类别 
        /// </summary> 
        /// <return></return>
        public object get_persontype() { return null; }
        /// <summary>
        /// 批量获取人员类别    
        /// </summary> 
        /// <return></return>
        public object batch_get_persontype() { return null; }
        /// <summary>
        /// 仓库  获取单个仓库信息 
        /// </summary> 
        /// <return></return>
        public object Get_Warehouse() { return null; }
        /// <summary>
        /// 批量获取仓库信息    
        /// </summary> 
        /// <return></return>
        public object batch_get_warehouse() { return null; }
        /// <summary>
        /// 新增一个仓库  
        /// </summary> 
        /// <return></return>
        public object add_warehouse() { return null; }
        /// <summary>
        /// 会计期间    批量获取会计期间 
        /// </summary> 
        /// <return></return>
        public object batch_get_period() { return null; }
        /// <summary>
        /// 供应商 获取单个供应商信息 
        /// </summary> 
        /// <return></return>
        public object get_vendor() { return null; }
        /// <summary>
        /// 修改一个供应商 
        /// </summary> 
        /// <return></return>
        public object edit_vendor() { return null; }
        /// <summary>
        /// 批量获取供应商信息   
        /// </summary> 
        /// <return></return>
        public object batch_get_vendor() { return null; }
        /// <summary>
        /// 添加一个新供应商    
        /// </summary> 
        /// <return></return>
        public object add_vendor() { return null; }
        /// <summary>
        /// 供应商分类   获取单个供应商分类信息 
        /// </summary> 
        /// <return></return>
        public object get_vendorclass() { return null; }
        /// <summary>
        /// 批量获取供应商分类信息 
        /// </summary> 
        /// <return></return>
        public object batch_get_vendorclass() { return null; }
        /// <summary>
        /// 添加一个新供应商分类  
        /// </summary> 
        /// <return></return>
        public object add_vendorclass() { return null; }
        /// <summary>
        /// 供应商银行   获取单个供应商银行信息 
        /// </summary> 
        /// <return></return>
        public object get_vendor_bank() { return null; }
        /// <summary>
        /// 批量获取供应商银行信息 
        /// </summary> 
        /// <return></return>
        public object batch_get_vendor_bank() { return null; }
        /// <summary>
        /// 凭证类别    获取单个凭证类别 
        /// </summary> 
        /// <return></return>
        public object get_dsign() { return null; }
        /// <summary>
        /// 批量获取凭证类别    
        /// </summary> 
        /// <return></return>
        public object batch_get_dsign() { return null; }
        /// <summary>
        /// 地区分类    获取单个地区分类 
        /// </summary> 
        /// <return></return>
        public object get_districtclass() { return null; }
        /// <summary>
        /// 批量获取地区分类    
        /// </summary> 
        /// <return></return>
        public object batch_get_districtclass() { return null; }
        /// <summary>
        /// 存货分类    获取单个存货分类信息 
        /// </summary> 
        /// <return></return>
        public object get_inventoryclass() { return null; }
        /// <summary>
        /// 批量获取存货分类信息  
        /// </summary> 
        /// <return></return>
        public object batch_get_inventoryclass() { return null; }
        /// <summary>
        /// 新增一张存货分类    
        /// </summary> 
        /// <return></return>
        public object add_inventoryclass() { return null; }
        /// <summary>
        /// 存货档案    获取单个存货信息 
        /// </summary> 
        /// <return></return>
        public object get_inventory() { return null; }
        /// <summary>
        /// 修改一个新存货 
        /// </summary> 
        /// <return></return>
        public object edit_inventory() { return null; }
        /// <summary>
        /// 批量获取存货信息    
        /// </summary> 
        /// <return></return>
        public object batch_get_inventory() { return null; }
        /// <summary>
        /// 添加一个新存货 
        /// </summary> 
        /// <return></return>
        public object add_inventory() { return null; }
        /// <summary>
        /// 客户  获取单个客户信息 
        /// </summary> 
        /// <return></return>
        public object get_customer() { return null; }
        /// <summary>
        /// 修改一个客户  
        /// </summary> 
        /// <return></return>
        public object edit_customer() { return null; }
        /// <summary>
        /// 批量获取客户信息    
        /// </summary> 
        /// <return></return>
        public object batch_get_customer() { return null; }
        /// <summary>
        /// 添加一个新客户 
        /// </summary> 
        /// <return></return>
        public object add_customer() { return null; }
        /// <summary>
        /// 客户分类    获取单个客户分类 
        /// </summary> 
        /// <return></return>
        public object get_customerclass() { return null; }
        /// <summary>
        /// 批量获取客户分类    
        /// </summary> 
        /// <return></return>
        public object batch_get_customerclass() { return null; }
        /// <summary>
        /// 添加一个新客户分类   
        /// </summary> 
        /// <return></return>
        public object add_customerclass() { return null; }
        /// <summary>
        /// 客户地址    获取单个客户地址 
        /// </summary> 
        /// <return></return>
        public object get_customeraddress() { return null; }
        /// <summary>
        /// 批量获取客户地址    
        /// </summary> 
        /// <return></return>
        public object batch_get_customeraddress() { return null; }
        /// <summary>
        /// 客户联系人   获取单个客户联系人 
        /// </summary> 
        /// <return></return>
        public object get_customercontacts() { return null; }
        /// <summary>
        /// 批量获取客户联系人   
        /// </summary> 
        /// <return></return>
        public object batch_get_customercontacts() { return null; }
        /// <summary>
        /// 客户银行    获取单个客户银行信息 
        /// </summary> 
        /// <return></return>
        public object get_customer_bank() { return null; }
        /// <summary>
        /// 批量获取客户银行信息  
        /// </summary> 
        /// <return></return>
        public object batch_get_customer_bank() { return null; }
        /// <summary>
        /// 币种  获取单个币种 
        /// </summary> 
        /// <return></return>
        public object get_currency() { return null; }
        /// <summary>
        /// 批量获取币种  
        /// </summary> 
        /// <return></return>
        public object batch_get_currency() { return null; }
        /// <summary>
        /// 常用摘要    获取单个常用摘要 
        /// </summary> 
        /// <return></return>
        public object get_digest() { return null; }
        /// <summary>
        /// 批量获取常用摘要    
        /// </summary> 
        /// <return></return>
        public object batch_get_digest() { return null; }
        /// <summary>
        /// 收发类别    获取单个收发类别 
        /// </summary> 
        /// <return></return>
        public object get_receivesendtype() { return null; }
        /// <summary>
        /// 批量获取收发类别    
        /// </summary> 
        /// <return></return>
        public object batch_get_receivesendtype() { return null; }
        /// <summary>
        /// 本单位开户银行 获取一个本单位开户银行 
        /// </summary> 
        /// <return></return>
        public object get_accountingbank() { return null; }
        /// <summary>
        /// 批量获取本单位开户银行 
        /// </summary> 
        /// <return></return>
        public object batch_get_accountingbank() { return null; }
        /// <summary>
        /// 新增一个本单位开户银行 
        /// </summary> 
        /// <return></return>
        public object add_accountingbank() { return null; }
        /// <summary>
        /// 现金流量项目  获取单个现金流量项目 
        /// </summary> 
        /// <return></return>
        public object get_cashflowitem() { return null; }
        /// <summary>
        /// 批量获取现金流量项目  
        /// </summary> 
        /// <return></return>
        public object batch_get_cashflowitem() { return null; }
        /// <summary>
        /// 科目  获取单个科目信息 
        /// </summary> 
        /// <return></return>
        public object get_code() { return null; }
        /// <summary>
        /// 批量获取科目信息    
        /// </summary> 
        /// <return></return>
        public object batch_get_code() { return null; }
        /// <summary>
        /// 结算方式    获取单个结算方式 
        /// </summary> 
        /// <return></return>
        public object get_settlestyle() { return null; }
        /// <summary>
        /// 批量获取结算方式    
        /// </summary> 
        /// <return></return>
        public object batch_get_settlestyle() { return null; }
        /// <summary>
        /// 编码方案    获取单个编码方案 
        /// </summary> 
        /// <return></return>
        public object get_codescheme() { return null; }
        /// <summary>
        /// 批量获取编码方案    
        /// </summary> 
        /// <return></return>
        public object batch_get_codescheme() { return null; }
        /// <summary>
        /// 职位档案    获取单个职位档案 
        /// </summary> 
        /// <return></return>
        public object get_job() { return null; }
        /// <summary>
        /// 批量获取职位档案    
        /// </summary> 
        /// <return></return>
        public object batch_get_job() { return null; }
        /// <summary>
        /// 职务档案    获取单个职务档案 
        /// </summary> 
        /// <return></return>
        public object get_duty() { return null; }
        /// <summary>
        /// 批量获取职务档案    
        /// </summary> 
        /// <return></return>
        public object batch_get_duty() { return null; }
        /// <summary>
        /// 职务类别    获取单个职务类别 
        /// </summary> 
        /// <return></return>
        public object get_dutytype() { return null; }
        /// <summary>
        /// 批量获取职务类别    
        /// </summary> 
        /// <return></return>
        public object batch_get_dutytype() { return null; }
        /// <summary>
        /// 自定义项档案  批量获取自定义项档案 
        /// </summary> 
        /// <return></return>
        public object batch_get_define() { return null; }
        /// <summary>
        /// 自由项 获取单个自由项信息 
        /// </summary> 
        /// <return></return>
        public object get_freearch() { return null; }
        /// <summary>
        /// 批量获取自由项信息   
        /// </summary> 
        /// <return></return>
        public object batch_get_freearch() { return null; }
        /// <summary>
        /// 计量单位    获取单个计量单位信息 
        /// </summary> 
        /// <return></return>
        public object get_unit() { return null; }
        /// <summary>
        /// 批量获取计量单位信息  
        /// </summary> 
        /// <return></return>
        public object batch_get_unit() { return null; }
        /// <summary>
        /// 费用项目    获取单个费用项目 
        /// </summary> 
        /// <return></return>
        public object get_expenseitem() { return null; }
        /// <summary>
        /// 批量获取费用项目    
        /// </summary> 
        /// <return></return>
        public object batch_get_expenseitem() { return null; }
        /// <summary>
        /// 费用项目分类  获取单个费用项目分类 
        /// </summary> 
        /// <return></return>
        public object get_expitemclass() { return null; }
        /// <summary>
        /// 批量获取费用项目分类  
        /// </summary> 
        /// <return></return>
        public object batch_get_expitemclass() { return null; }
        /// <summary>
        /// 部门  获取单个部门信息 
        /// </summary> 
        /// <return></return>
        public object get_department() { return null; }
        /// <summary>
        /// 修改一个部门  
        /// </summary> 
        /// <return></return>
        public object edit_department() { return null; }
        /// <summary>
        /// 批量获取部门信息    
        /// </summary> 
        /// <return></return>
        public object batch_get_department() { return null; }
        /// <summary>
        /// 添加一个新部门 
        /// </summary> 
        /// <return></return>
        public object add_department() { return null; }
        /// <summary>
        /// 银行  获取单个银行信息 
        /// </summary> 
        /// <return></return>
        public object get_bank() { return null; }
        /// <summary>
        /// 批量获取银行信息    
        /// </summary> 
        /// <return></return>
        public object batch_get_bank() { return null; }
        /// <summary>
        /// 销售类型    获取单个销售类型 
        /// </summary> 
        /// <return></return>
        public object get_saletype() { return null; }
        /// <summary>
        /// 批量获取销售类型    
        /// </summary> 
        /// <return></return>
        public object batch_get_saletype() { return null; }
        /// <summary>
        /// 项目  批量获取项目信息 
        /// </summary> 
        /// <return></return>
        public object batch_get_fitem() { return null; }
        /// <summary>
        /// 添加一个新项目 
        /// </summary> 
        /// <return></return>
        public object add_fitem() { return null; }
        /// <summary>
        /// 项目分类    批量获取项目分类 
        /// </summary> 
        /// <return></return>
        public object batch_get_fitemclass() { return null; }
        /// <summary>
        /// 项目大类    获取单个项目大类 
        /// </summary> 
        /// <return></return>
        public object get_fitemcategory() { return null; }
        /// <summary>
        /// 批量获取项目大类    
        /// </summary> 
        /// <return></return>
        public object batch_get_fitemcategory() { return null; }
    }
}
