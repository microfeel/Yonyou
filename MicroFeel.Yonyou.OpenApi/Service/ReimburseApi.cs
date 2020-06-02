namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 网上报销API 10
    /// </summary>
    public class ReimburseApi : Api
    {
        public ReimburseApi() : base("api") { }

        /// <summary>
        /// 商旅订单 获取单张商旅订单    
        /// </summary> 
        /// <return></return>
        public object get_businesstravelorder() { return null; }
        /// <summary>
        /// 新增一张商旅订单    
        /// </summary> 
        /// <return></return>
        public object add_businesstravelorder() { return null; }
        /// <summary>
        /// 费用报销单   获取费用报销单列表信息 
        /// </summary> 
        /// <return></return>
        public object batch_get_expensesclaimlist() { return null; }
        /// <summary>
        /// 获取费用报销单待办任务 
        /// </summary> 
        /// <return></return>
        public object tasks_expensesclaim() { return null; }
        /// <summary>
        /// 获取费用报销单审批进程 
        /// </summary> 
        /// <return></return>
        public object history_expensesclaim() { return null; }
        /// <summary>
        /// 获取单张费用报销单   
        /// </summary> 
        /// <return></return>
        public object get_expensesclaim() { return null; }
        /// <summary>
        /// 获取费用报销单工作流按钮是否可用状态  
        /// </summary> 
        /// <return></return>
        public object buttonstate_expensesclaim() { return null; }
        /// <summary>
        /// 审核费用报销单 
        /// </summary> 
        /// <return></return>
        public object audit_expensesclaim() { return null; }
        /// <summary>
        /// 新增一张费用报销单   
        /// </summary> 
        /// <return></return>
        public object add_expensesclaim() { return null; }
        /// <summary>
        /// 弃审费用报销单 
        /// </summary> 
        /// <return></return>
        public object abandon_expensesclaim() { return null; }

    }
}
