using MicroFeel.Finance.Interfaces;
using MicroFeel.Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Services
{
    public class PlatformService : IPlatformService
    {
        private MicroFeel.Yonyou.Api.Service.SystemApi systemApi;

        public PlatformService()
        {
            systemApi = new Api.Service.SystemApi();
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public async Task<IEnumerable<Datasource>> GetBatchDatasourceAsync()
        {
            var result = await systemApi.Batch_get_DatasourceAsync();
            return result.Select(t => t.To<Datasource>(m => m.SystemInfo = t.U8.To<SystemInfo>()));
        }

        public async Task<OrderStatus> GetOrderStatusAsync()
        {
            var result = await systemApi.Get_OrderStatusAsync();
            return result.To<OrderStatus>();
        }

        public async Task<Datasource> Get_DatasourceAsync()
        {
            var result = await systemApi.Get_DatasourceAsync();
            return result.To<Datasource>();
        }

        public async Task<string> TokenAsync()
        {
            var result = await systemApi.TokenAsync();
            return result;
        }

        public async Task<string> TradeidAsync()
        {
            var result = await systemApi.TradeidAsync();
            return result;
        }
    }
}
