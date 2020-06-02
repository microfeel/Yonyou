namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 资源管理类API
    /// </summary>
    public class ResourceApi : Api
    {
        public ResourceApi() : base("api") { }


        /// <summary>
        /// 客户资质审批 获取单个客户资质审批  
        /// </summary> 
        /// <return></return>
        public object get_customerlicence() { return null; }
        /// <summary>
        /// 批量获取客户资质审批  
        /// </summary> 
        /// <return></return>
        public object batch_get_customerlicence() { return null; }
        /// <summary>
        /// 客户资质经营范围审批  获取单个客户资质经营范围审批 
        /// </summary> 
        /// <return></return>
        public object get_customerlicencebizscope() { return null; }
        /// <summary>
        /// 批量获取客户资质经营范围审批  
        /// </summary> 
        /// <return></return>
        public object batch_get_customerlicencebizscope() { return null; }

    }
}
