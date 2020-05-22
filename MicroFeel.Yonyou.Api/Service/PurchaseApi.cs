using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroFeel.Yonyou.Api.Model.Result;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 采购管理API  57
    /// </summary>
    public class PurchaseApi : Api
    {
        public PurchaseApi() : base("api") { }
        /// <summary>
        /// 供应商存货价格表 批量获取供应商存货价格表信息  
        /// </summary> 
        /// <return></return>
        public object Batch_Get_Veninvprice()
        {
            return null;
        }
        /// <summary>
        /// 供应商存货调价单    获取供应商存货调价单列表信息 
        /// </summary> 
        /// <return></return>
        public async Task<List<Venpriceadjust>> Batch_Get_VenpriceadjustlistAsync(int dsSequence = 1)
        {
            return (await GetsSync<Venpriceadjust>(dsSequence)).List;
        }
        /// <summary>
        /// 获取供应商存货调价单待办任务  
        /// </summary> 
        /// <return></return>
        public object tasks_venpriceadjust() { return null; }
        /// <summary>
        /// 获取供应商存货调价单审批进程  
        /// </summary> 
        /// <return></return>
        public object history_venpriceadjust() { return null; }
        /// <summary>
        /// 获取单张供应商存货调价单    
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<VenpriceadjustResult> Get_VenpriceadjustAsync(string id, int dsSequence = 1)
        {
            return await GetSync<VenpriceadjustResult>(id, dsSequence);
        }
        /// <summary>
        /// 获取供应商存货调价单工作流按钮是否可用状态   
        /// </summary> 
        /// <return></return>
        public object buttonstate_venpriceadjust() { return null; }
        /// <summary>
        /// 审核供应商存货调价单  
        /// </summary> 
        /// <return></return>
        public object audit_venpriceadjust() { return null; }
        /// <summary>
        /// 新增一张供应商存货调价单    
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<DbResult> Add_VenpriceadjustAsync(Venpriceadjust venpriceadjust, int dsSequence = 1, bool sync = true)
        {
            return await AddSync(venpriceadjust, dsSequence, sync);
        }
        /// <summary>
        /// 弃审供应商存货调价单  
        /// </summary> 
        /// <return></return>
        public object abandon_venpriceadjust() { return null; }
        /// <summary>
        /// 采购到货单   审核一张采购到货单 
        /// </summary> 
        /// <return></return>
        public object verify_purchasereceipt() { return null; }

        public Task Get_PurchaseorderlistAsync(int v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 弃审一张采购到货单   
        /// </summary> 
        /// <return></return>
        public object unverify_purchasereceipt() { return null; }
        /// <summary>
        /// 获取采购到货单待办任务 
        /// </summary> 
        /// <return></return>
        public object tasks_purchasereceipt() { return null; }
        /// <summary>
        /// 获取采购到货单审批进程 
        /// </summary> 
        /// <return></return>
        public object history_purchasereceipt() { return null; }
        /// <summary>
        /// 获取单张采购到货单   
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<PurchasereceiptResult> Get_PurchasereceiptAsync(string id, int dsSequence = 1)
        {
            return await GetSync<PurchasereceiptResult>(id, dsSequence);
        }
        /// <summary>
        /// 获取采购到货单是否启用工作流  
        /// </summary> 
        /// <return></return>
        public object flowenabled_purchasereceipt() { return null; }
        /// <summary>
        /// 获取采购到货单工作流按钮是否可用状态  
        /// </summary> 
        /// <return></return>
        public object buttonstate_purchasereceipt() { return null; }
        /// <summary>
        /// 审核采购到货单（工作流） 
        /// </summary> 
        /// <return></return>
        public object audit_purchasereceipt() { return null; }
        /// <summary>
        /// 新增一张采购到货单   
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<DbResult> Add_PurchasereceiptAsync(Purchasereceipt purchasereceipt, int dsSequence = 1, bool sync = true)
        {
            return await AddSync(purchasereceipt, dsSequence, sync);
        }
        /// <summary>
        /// 弃审采购到货单 
        /// </summary> 
        /// <return></return>
        public object abandon_purchasereceipt() { return null; }
        /// <summary>
        /// 采购到货单列表 获取采购到货单列表 
        /// </summary> 
        /// <return></return>
        public async Task<List<Purchasereceipt>> Batch_Get_PurchasereceiptlistAsync(int dsSequence)
        {
            return (await GetsSync<Purchasereceipt>(dsSequence)).List;
        }
        /// <summary>
        /// 采购发票    获取采购发票列表信息 
        /// </summary> 
        /// <return></return>
        public object Batch_Get_Purinvoicelist() { return null; }
        /// <summary>
        /// 获取单张采购发票    
        /// </summary> 
        /// <return></return>
        public object Get_Purinvoice() { return null; }
        /// <summary>
        /// 新增一张采购发票    
        /// </summary> 
        /// <return></return>
        public async Task<DbResult> Add_PurchaseinvoiceAsync(Purchaseinvoice purchaseinvoice, int dsSequence = 1, bool sync = true)
        {
            return await AddSync(purchaseinvoice, dsSequence, sync);
        }
        /// <summary>
        /// 采购结账状态  批量获取采购结账状态 
        /// </summary> 
        /// <return></return>
        public object batch_get_mendpu() { return null; }
        /// <summary>
        /// 采购订单    批量获取采购订单（以存货为单位） 
        /// </summary> 
        /// <return></return>
        public object Batch_Get_Purchaseorderlist2() { return null; }
        /// <summary>
        /// 获取采购订单列表信息  
        /// </summary> 
        /// <return></return>
        public async Task<List<Purchaseorder>> Batch_Get_PurchaseorderlistAsync(int dsSequence = 1)
        {
            return (await GetsSync<Purchaseorder>(dsSequence)).List;
        }
        /// <summary>
        /// 审核一张采购订单    
        /// </summary> 
        /// <return></return>
        public object verify_purchaseorder() { return null; }
        /// <summary>
        /// 弃审一张采购订单    
        /// </summary> 
        /// <return></return>
        public object unverify_purchaseorder() { return null; }
        /// <summary>
        /// 获取采购订单待办任务  
        /// </summary> 
        /// <return></return>
        public object tasks_purchaseorder() { return null; }
        /// <summary>
        /// 获取采购订单审批进程  
        /// </summary> 
        /// <return></return>
        public object history_purchaseorder() { return null; }
        /// <summary>
        /// 获取单张采购订单    
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<PurchaseorderResult> Get_PurchaseorderAsync(string id, int dsSequence = 1)
        {
            return await GetSync<PurchaseorderResult>(id, dsSequence);
        }
        /// <summary>
        /// 获取采购订单工作流按钮是否可用状态   
        /// </summary> 
        /// <return></return>
        public object buttonstate_purchaseorder() { return null; }
        /// <summary>
        /// 审核采购订单  
        /// </summary> 
        /// <return></return>
        public object audit_purchaseorder() { return null; }
        /// <summary>
        /// 新增一张采购订单    
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<DbResult> Add_PurchaseorderAsync(Purchaseorder purchaseorder, string bizid, int dsSequence = 1, bool sync = true)
        {
            return await AddSync(purchaseorder, dsSequence, sync, bizid);
        }
        /// <summary>
        /// 弃审采购订单  
        /// </summary> 
        /// <return></return>
        public object abandon_purchaseorder() { return null; }
        /// <summary>
        /// 采购请购单   获取请购单列表 
        /// </summary> 
        /// <return></return>
        public async Task<List<Purchaserequisition>> Batch_Get_PurchaserequisitionlistAsync(int dsSequence = 1)
        {
            return (await GetsSync<Purchaserequisition>(dsSequence)).List;
        }
        /// <summary>
        /// 审核一张采购请购单   
        /// </summary> 
        /// <return></return>
        public object verify_purchaserequisition() { return null; }
        /// <summary>
        /// 弃审一张采购请购单   
        /// </summary> 
        /// <return></return>
        public object unverify_purchaserequisition() { return null; }
        /// <summary>
        /// 获取采购请购单待办任务 
        /// </summary> 
        /// <return></return>
        public object tasks_purchaserequisition() { return null; }
        /// <summary>
        /// 获取采购请购单审批进程 
        /// </summary> 
        /// <return></return>
        public object history_purchaserequisition() { return null; }
        /// <summary>
        /// 获取单个请购单 
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<PurchaserequisitionResult> Get_PurchaserequisitionAsync(string id, int dsSequence = 1)
        {
            return await GetSync<PurchaserequisitionResult>(id, dsSequence);
        }
        /// <summary>
        /// 获取采购请购单是否启用工作流  
        /// </summary> 
        /// <return></return>
        public object flowenabled_purchaserequisition() { return null; }
        /// <summary>
        /// 获取采购请购单工作流按钮是否可用状态  
        /// </summary> 
        /// <return></return>
        public object buttonstate_purchaserequisition() { return null; }
        /// <summary>
        /// 审核采购请购单（工作流） 
        /// </summary> 
        /// <return></return>
        public object audit_purchaserequisition() { return null; }
        /// <summary>
        /// 新增一张请购单 
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<DbResult> Add_PurchaserequisitionAsync(Purchaserequisition purchaserequisition, int dsSequence = 1, bool sync = true)
        {
            return await AddSync(purchaserequisition, dsSequence, sync);
        }
        /// <summary>
        /// 弃审采购请购单 
        /// </summary> 
        /// <return></return>
        public object abandon_purchaserequisition() { return null; }
        /// <summary>
        /// 采购退货单   获取采购退货单列表信息 
        /// </summary> 
        /// <return></return>
        public async Task<List<Purchasereturn>> Batch_Get_PurchasereturnlistAsync(int dsSequence = 1)
        {
            return (await GetsSync<Purchasereturn>(dsSequence)).List;
        }
        /// <summary>
        /// 审核一张采购退货单   
        /// </summary> 
        /// <return></return>
        public object verify_purchasereturn() { return null; }
        /// <summary>
        /// 弃审一张采购退货单   
        /// </summary> 
        /// <return></return>
        public object unverify_purchasereturn() { return null; }
        /// <summary>
        /// 获取采购退货单待办任务 
        /// </summary> 
        /// <return></return>
        public object tasks_purchasereturn() { return null; }
        /// <summary>
        /// 获取采购退货单审批进程 
        /// </summary> 
        /// <return></return>
        public object history_purchasereturn() { return null; }
        /// <summary>
        /// 获取单张采购退货单   
        /// </summary> 
        /// <return></return>
        public async Task<PurchasereturnResult> Get_PurchasereturnAsync(string id, int dsSequence = 1)
        {
            return await GetSync<PurchasereturnResult>(id, dsSequence);
        }
        /// <summary>
        /// 获取采购退货单是否启用工作流  
        /// </summary> 
        /// <return></return>
        public object flowenabled_purchasereturn() { return null; }
        /// <summary>
        /// 获取采购退货单工作流按钮是否可用状态  
        /// </summary> 
        /// <return></return>
        public object buttonstate_purchasereturn() { return null; }
        /// <summary>
        /// 审核采购退货单（工作流） 
        /// </summary> 
        /// <return></return>
        public object audit_purchasereturn() { return null; }
        /// <summary>
        /// 新增一张采购退货单   
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<DbResult> Add_PurchasereturnAsync(Purchasereturn purchasereturn, int dsSequence = 1, bool sync = true)
        {
            return await AddSync(purchasereturn, dsSequence, sync);
        }
        /// <summary>
        /// 弃审采购退货单 
        /// </summary> 
        /// <return></return>
        public object abandon_purchasereturn() { return null; }

    }
}
