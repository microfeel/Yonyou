using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 应收应付类APi   35
    /// </summary>
    public class ArApApi : Api
    {
        public ArApApi() : base("api") { }

        /// <summary>
        /// 付款单 获取付款单列表信息   
        /// </summary> 
        /// <return></return>
        public object batch_get_paylist() { return null; }
        /// <summary>
        /// 审核一张付款单 
        /// </summary> 
        /// <return></return>
        public object verify_pay() { return null; }
        /// <summary>
        /// 弃审一张付款单 
        /// </summary> 
        /// <return></return>
        public object unverify_pay() { return null; }
        /// <summary>
        /// 获取付款单待办任务   
        /// </summary> 
        /// <return></return>
        public object tasks_pay() { return null; }
        /// <summary>
        /// 获取付款单审批进程   
        /// </summary> 
        /// <return></return>
        public object history_pay() { return null; }
        /// <summary>
        /// 获取单张付款单 
        /// </summary> 
        /// <return></return>
        public object get_pay() { return null; }
        /// <summary>
        /// 获取付款单是否启用工作流    
        /// </summary> 
        /// <return></return>
        public object flowenabled_pay() { return null; }
        /// <summary>
        /// 获取付款单工作流按钮是否可用状态    
        /// </summary> 
        /// <return></return>
        public object buttonstate_pay() { return null; }
        /// <summary>
        /// 审核付款单   
        /// </summary> 
        /// <return></return>
        public object audit_pay() { return null; }
        /// <summary>
        /// 新增一张付款单 
        /// </summary> 
        /// <return></return>
        public object add_pay() { return null; }
        /// <summary>
        /// 弃审付款单   
        /// </summary> 
        /// <return></return>
        public object abandon_pay() { return null; }
        /// <summary>
        /// 付款申请单   获取付款申请单列表 
        /// </summary> 
        /// <return></return>
        public object batch_get_payrequestlist() { return null; }
        /// <summary>
        /// 获取付款申请单待办任务 
        /// </summary> 
        /// <return></return>
        public object tasks_payrequest() { return null; }
        /// <summary>
        /// 撤销付款申请单 
        /// </summary> 
        /// <return></return>
        public object return_payrequest() { return null; }
        /// <summary>
        /// 获取付款申请单审批进程 
        /// </summary> 
        /// <return></return>
        public object history_payrequest() { return null; }
        /// <summary>
        /// 获取单个付款申请单   
        /// </summary> 
        /// <return></return>
        public object get_payrequest() { return null; }
        /// <summary>
        /// 获取付款申请单是否启用工作流  
        /// </summary> 
        /// <return></return>
        public object flowenabled_payrequest() { return null; }
        /// <summary>
        /// 获取付款申请单工作流按钮是否可用状态  
        /// </summary> 
        /// <return></return>
        public object buttonstate_payrequest() { return null; }
        /// <summary>
        /// 审核付款申请单（工作流） 
        /// </summary> 
        /// <return></return>
        public object audit_payrequest() { return null; }
        /// <summary>
        /// 弃审付款申请单 
        /// </summary> 
        /// <return></return>
        public object abandon_payrequest() { return null; }
        /// <summary>
        /// 应付单 获取应付单列表 
        /// </summary> 
        /// <return></return>
        public object batch_get_oughtpaylist() { return null; }
        /// <summary>
        /// 审核一张应付单 
        /// </summary> 
        /// <return></return>
        public object verify_oughtpay() { return null; }
        /// <summary>
        /// 弃审一张应付单 
        /// </summary> 
        /// <return></return>
        public object unverify_oughtpay() { return null; }
        /// <summary>
        /// 获取单个应付单 
        /// </summary> 
        /// <return></return>
        public object get_oughtpay() { return null; }
        /// <summary>
        /// 新增一张应付单 
        /// </summary> 
        /// <return></return>
        public object add_oughtpay() { return null; }
        /// <summary>
        /// 应收单 获取应收单列表信息 
        /// </summary> 
        /// <return></return>
        public object batch_get_oughtreceivelist() { return null; }
        /// <summary>
        /// 审核一张应收单 
        /// </summary> 
        /// <return></return>
        public object verify_oughtreceive() { return null; }
        /// <summary>
        /// 弃审一张应收单 
        /// </summary> 
        /// <return></return>
        public object unverify_oughtreceive() { return null; }
        /// <summary>
        /// 获取单张应收单 
        /// </summary> 
        /// <return></return>
        public object get_oughtreceive() { return null; }
        /// <summary>
        /// 新增一张应收单 
        /// </summary> 
        /// <return></return>
        public object add_oughtreceive() { return null; }
        /// <summary>
        /// 收款单 获取收款单列表信息 
        /// </summary> 
        /// <return></return>
        public object batch_get_acceptlist() { return null; }
        /// <summary>
        /// 审核一张收款单 
        /// </summary> 
        /// <return></return>
        public object verify_accept() { return null; }
        /// <summary>
        /// 弃审一张收款单 
        /// </summary> 
        /// <return></return>
        public object unverify_accept() { return null; }
        /// <summary>
        /// 获取单张收款单 
        /// </summary> 
        /// <return></return>
        public object get_accept() { return null; }
        /// <summary>
        /// 新增一张收款单 
        /// </summary> 
        /// <return></return>
        public object add_accept() { return null; }
    }
}
