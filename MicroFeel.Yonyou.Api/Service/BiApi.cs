using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 商业智能API
    /// </summary>
    public class BiApi : Api
    {
        public BiApi() : base("api") { }

        /// <summary>
        ///  EVA体检模型 获取EVA体检模型信息 
        /// </summary>
        /// <returns></returns>
        public object batch_get_eva() { return null; }
        /// <summary>
        /// 商业盈利状况评价    获取商业盈利状况评价信息 
        /// </summary>
        /// <returns></returns>
        public object batch_get_productprofitability() { return null; }
        /// <summary>
        /// 资金体检模型  获取资金体检模型信息
        /// </summary>
        /// <returns></returns>
        public object batch_get_fund() { return null; }

    }
}
