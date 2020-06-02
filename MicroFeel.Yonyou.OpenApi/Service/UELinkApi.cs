using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// U易联API
    /// </summary>
    public class UELinkApi : Api
    {
        public UELinkApi() : base("api") { }

        /// <summary>
        /// U易联会员档案 会员档案查询  
        /// </summary> 
        /// <return></return>
        public object query_member() { return null; }
        /// <summary>
        /// 会员级别档案  会员级别档案查询 
        /// </summary> 
        /// <return></return>
        public object query_memberlevel() { return null; }
        /// <summary>
        /// 积分增加    积分增加 
        /// </summary> 
        /// <return></return>
        public object change_points() { return null; }
        /// <summary>
        /// 积分明细    积分明细查询 
        /// </summary> 
        /// <return></return>
        public object query_points() { return null; }
        /// <summary>
        /// 订单交易记录  订单交易记录查询 
        /// </summary> 
        /// <return></return>
        public object query_orders() { return null; }

    }
}
