using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 电商API
    /// </summary>
    public class ECApi : Api
    {
        public ECApi() : base("api") { }
        /// <summary>
        /// 店铺商品档案 批量获取店铺商品档案  
        /// </summary> 
        /// <return></return>
        public object batch_get_eb_iteminvcontrapose() { return null; }
        /// <summary>
        /// 新增一个店铺商品    
        /// </summary> 
        /// <return></return>
        public object add_eb_iteminvcontrapose() { return null; }
        /// <summary>
        /// 电商订单    批量获取新电商订单列表 
        /// </summary> 
        /// <return></return>
        public object batch_get_eb_tradelist_v2() { return null; }
        /// <summary>
        /// 获取电商订单列表    
        /// </summary> 
        /// <return></return>
        public object batch_get_eb_tradelist() { return null; }
        /// <summary>
        /// 获取单个新电商订单   
        /// </summary> 
        /// <return></return>
        public object get_eb_trade_v2() { return null; }
        /// <summary>
        /// 批量获取新电商订单   
        /// </summary> 
        /// <return></return>
        public object batch_get_eb_trade_v2() { return null; }
        /// <summary>
        /// 获取单个电商订单    
        /// </summary> 
        /// <return></return>
        public object get_eb_trade() { return null; }
        /// <summary>
        /// 新增一张电商订单    
        /// </summary> 
        /// <return></return>
        public object add_eb_trade() { return null; }

    }
}
