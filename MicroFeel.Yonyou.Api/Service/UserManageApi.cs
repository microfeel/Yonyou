using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 用户管理类API
    /// </summary>
    public class UserManageApi : Api
    {
        public UserManageApi() : base("api") { }
        /// <summary>
        /// U8模块启用状态 获取U8某模块的启用状态    
        /// </summary> 
        /// <return></return>
        public object batch_get_systemstate() { return null; }
        /// <summary>
        /// 操作员 获取单个操作员 
        /// </summary> 
        /// <return></return>
        public object get_operator() { return null; }
        /// <summary>
        /// 批量获取操作员 
        /// </summary> 
        /// <return></return>
        public object batch_get_operator() { return null; }
        /// <summary>
        /// 用户  用户登录v2 
        /// </summary> 
        /// <return></return>
        public object login_v2_user() { return null; }
        /// <summary>
        /// 用户登录    
        /// </summary> 
        /// <return></return>
        public object login_user() { return null; }

    }
}
