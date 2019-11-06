namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 人力资源管理API  8
    /// </summary>
    public class HrApi : Api
    {
        public HrApi() : base("api") { }

        /// <summary>
        /// 员工任职信息 获取单个员工任职信息  
        /// </summary> 
        /// <return></return>
        public object get_jobinfo() { return null; }
        /// <summary>
        /// 批量获取员工任职信息  
        /// </summary> 
        /// <return></return>
        public object batch_get_jobinfo() { return null; }
        /// <summary>
        /// 工资记录    获取某个员工工资记录 
        /// </summary> 
        /// <return></return>
        public object get_salary() { return null; }
        /// <summary>
        /// 批量获取员工工资记录  
        /// </summary> 
        /// <return></return>
        public object batch_get_salary() { return null; }
        /// <summary>
        /// 工资项目    获取单个工资项目 
        /// </summary> 
        /// <return></return>
        public object get_salaryitem() { return null; }
        /// <summary>
        /// 批量获取工资项目    
        /// </summary> 
        /// <return></return>
        public object batch_get_salaryitem() { return null; }
        /// <summary>
        /// 考勤  批量获取考勤信息 
        /// </summary> 
        /// <return></return>
        public object batch_get_attendance() { return null; }
        /// <summary>
        /// 薪资结账状态  批量获取薪资结账状态 
        /// </summary> 
        /// <return></return>
        public object batch_get_mendwa() { return null; }

    }
}
