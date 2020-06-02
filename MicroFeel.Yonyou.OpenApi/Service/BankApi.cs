using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 网上银行API
    /// </summary>
    public class BankApi : Api
    {
        public BankApi() : base("api") { }

        /// <summary>
        /// 对私支付单 获取单个对私支付单   
        /// </summary> 
        /// <return></return>
        public object get_privatepayment() { return null; }
        /// <summary>
        /// 批量获取对私支付单   
        /// </summary> 
        /// <return></return>
        public object batch_get_privatepayment() { return null; }
        /// <summary>
        /// 对私支付单   
        /// </summary> 
        /// <return></return>
        public object add_privatepayment() { return null; }
        /// <summary>
        /// 普通支付单   获取单个普通支付单 
        /// </summary> 
        /// <return></return>
        public object get_payment() { return null; }
        /// <summary>
        /// 批量获取普通支付单   
        /// </summary> 
        /// <return></return>
        public object batch_get_payment() { return null; }
        /// <summary>
        /// 普通支付单   
        /// </summary> 
        /// <return></return>
        public object add_payment() { return null; }


    }
}
