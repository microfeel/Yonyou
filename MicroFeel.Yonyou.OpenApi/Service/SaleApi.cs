using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MicroFeel.Yonyou.Api.Model.Result;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 销售管理API  33个
    /// </summary>
    public class SaleApi : Api
    {
        public SaleApi() : base("api") { }

        /// <summary>
        /// 发货单 获取发货单列表信息   
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<List<Consignment>> Batch_Get_ConsignmentlistAsync(int dsSequence)
        {
            return (await GetsSync<Consignment>(dsSequence)).List;
        }
        /// <summary>
        /// 审核一张发货单 
        /// </summary> 
        /// <return></return>
        public object verify_consignment() { return null; }
        /// <summary>
        /// 弃审一张发货单 
        /// </summary> 
        /// <return></return>
        public object unverify_consignment() { return null; }
        /// <summary>
        /// 获取发货单待办任务   
        /// </summary> 
        /// <return></return>
        public object tasks_consignment() { return null; }
        /// <summary>
        /// 获取发货单审批进程   
        /// </summary> 
        /// <return></return>
        public object history_consignment() { return null; }
        /// <summary>
        /// 获取单张发货单 
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<ConsignmentResult> Get_ConsignmentAsync(string id, int dsSequence)
        {
            return await GetSync<ConsignmentResult>(id, dsSequence);
        }
        /// <summary>
        /// 获取发货单工作流按钮是否可用状态    
        /// </summary> 
        /// <return></return>
        public object buttonstate_consignment() { return null; }
        /// <summary>
        /// 审核发货单   
        /// </summary> 
        /// <return></return>
        public object audit_consignment() { return null; }
        /// <summary>
        /// 新增一张发货单 
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<DbResult> Add_ConsignmentAsync(Consignment  consignment, int dsSequence = 1, bool sync = true, [CallerMemberName] string callername = "")
        {
            return await AddSync(consignment, dsSequence, sync, callername);
        }
        /// <summary>
        /// 弃审发货单   
        /// </summary> 
        /// <return></return>
        public object abandon_consignment() { return null; }
        /// <summary>
        /// 客户调价单   获取单个客户调价单 
        /// </summary> 
        /// <return></return>
        public object get_cuspricejust() { return null; }
        /// <summary>
        /// 批量获取客户调价单   
        /// </summary> 
        /// <return></return>
        public object batch_get_cuspricejust() { return null; }
        /// <summary>
        /// 销售发票    获取销售发票列表 
        /// </summary> 
        /// <return></return>
        public object batch_get_saleinvoicelist() { return null; }
        /// <summary>
        /// 获取单个单张销售发票  
        /// </summary> 
        /// <return></return>
        public object get_saleinvoice() { return null; }
        /// <summary>
        /// 新增一张销售发票    
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<DbResult> Add_SaleinvoiceAsync(Saleinvoice  saleinvoice, int dsSequence = 1, bool sync = true, [CallerMemberName] string callername = "")
        {
            return await AddSync(saleinvoice, dsSequence, sync, callername);
        }
        /// <summary>
        /// 销售结账状态  批量获取销售结账状态 
        /// </summary> 
        /// <return></return>
        public object batch_get_mendsa() { return null; }
        /// <summary>
        /// 销售订单    获取销售订单列表信息 
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<List<Saleorder>> Batch_Get_SaleorderlistAsync(int dsSequence)
        {
            return (await GetsSync<Saleorder>(dsSequence)).List;
        }
        /// <summary>
        /// 审核一张销售订单    
        /// </summary> 
        /// <return></return>
        public object verify_saleorder() { return null; }
        /// <summary>
        /// 弃审一张销售订单    
        /// </summary> 
        /// <return></return>
        public object unverify_saleorder() { return null; }
        /// <summary>
        /// 获取销售订单待办任务  
        /// </summary> 
        /// <return></return>
        public object tasks_saleorder() { return null; }
        /// <summary>
        /// 打开一张销售订单    
        /// </summary> 
        /// <return></return>
        public object open_saleorder() { return null; }
        /// <summary>
        /// 获取销售订单审批进程  
        /// </summary> 
        /// <return></return>
        public object history_saleorder() { return null; }
        /// <summary>
        /// 获取单张销售订单    
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<SaleorderResult> Get_SaleorderAsync(string id, int dsSequence)
        {
            return await GetSync<SaleorderResult>(id, dsSequence);
        }
        /// <summary>
        /// 关闭一张销售订单    
        /// </summary> 
        /// <return></return>
        public object close_saleorder() { return null; }
        /// <summary>
        /// 获取销售订单工作流按钮是否可用状态   
        /// </summary> 
        /// <return></return>
        public object buttonstate_saleorder() { return null; }
        /// <summary>
        /// 审核销售订单  
        /// </summary> 
        /// <return></return>
        public object audit_saleorder() { return null; }
        /// <summary>
        /// 新增一张销售订单    
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<DbResult> Add_SaleorderAsync(Saleorder  saleorder, int dsSequence = 1, bool sync = true, [CallerMemberName] string callername = "")
        {
            return await AddSync(saleorder, dsSequence, sync, callername);
        }
        /// <summary>
        /// 弃审销售订单  
        /// </summary> 
        /// <return></return>
        public object abandon_saleorder() { return null; }
        /// <summary>
        /// 销售退货单   获取销售退货单列表信息 
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<List<Returnorder>> Batch_Get_ReturnorderlistAsync(int dsSequence)
        {
            return (await GetsSync<Returnorder>(dsSequence)).List;
        }
        /// <summary>
        /// 审核一张销售退货单   
        /// </summary> 
        /// <return></return>
        public object verify_returnorder() { return null; }
        /// <summary>
        /// 弃审一张销售退货单   
        /// </summary> 
        /// <return></return>
        public object unverify_returnorder() { return null; }
        /// <summary>
        /// 获取单个销售退货单   
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<Returnorder> Get_ReturnorderAsync(string id, int dsSequence)
        {
            return (await GetSync<ReturnorderResult>(id, dsSequence)).Returnorder;
        }
        /// <summary>
        /// 新增一张销售退货单   
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<DbResult> Add_ReturnorderAsync(Returnorder returnorder, int dsSequence=1,bool sync=true, [CallerMemberName] string callername = "") 
        {
            return await AddSync(returnorder, dsSequence, sync, callername);
        } 
    }
}
