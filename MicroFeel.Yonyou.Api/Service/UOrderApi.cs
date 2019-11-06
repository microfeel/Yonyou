using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// U订货API
    /// </summary>
    public class UOrderApi : Api
    {
        public UOrderApi() : base("api") { }

        /// <summary>
        /// 订单管理 批量获取订单信息    
        /// </summary> 
        /// <return></return>
        public object batch_get_orderlist() { return null; }

    }
}
