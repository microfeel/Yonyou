using System;
using System.Collections.Generic;
using System.Text;
using MicroFeel.Yonyou.Api.Model.Result;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 物料清单类API
    /// </summary>
    public class BomApi : Api
    {
        public BomApi() : base("api") { }

        /// <summary>
        /// 物料清单 获取单个物料清单    
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<BomResult> Get_BomAsync(string id, int dsSequence = 1)
        {
            return await GetSync<BomResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取物料清单    
        /// </summary> 
        /// <return></return>
        public async System.Threading.Tasks.Task<List<Bom>> Batch_Get_BomAsync(int dsSequence = 1)
        {
            return (await GetsSync<Bom>(dsSequence)).List;
        }

    }
}
