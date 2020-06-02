namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 费用预算类API
    /// </summary> 
    public class BudgetApi : Api
    {

        public BudgetApi() : base("api") { }

        /// <summary>
        /// 费用预算 预算查看    
        /// </summary> 
        /// <return></return>
        public object query_budget() { return null; }
        /// <summary>
        /// 预算控制    
        /// </summary> 
        /// <return></return>
        public object check_budget() { return null; }
        /// <summary>
        /// 预算项目    获取一个预算项目 
        /// </summary> 
        /// <return></return>
        public object get_budgetitem() { return null; }
        /// <summary>
        /// 批量获取预算项目    
        /// </summary> 
        /// <return></return>
        public object batch_get_budgetitem() { return null; }

    }
}
