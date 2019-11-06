using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Api.Service
{
    public class SystemApi : Api
    {
        public SystemApi() : base("system") { }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        public async Task<string> TokenAsync()
        {
            var req = await GetRequestTypeAsync<TokenRequest>();
            var tokenResult = await CallAsync<TokenRequest, TokenResult>(req);
            return tokenResult.Token.Id;
        }

        /// <summary>
        /// 获取交易号
        /// </summary>
        /// <returns>交易号</returns>
        public async Task<string> TradeidAsync()
        {
            var req = await GetRequestTypeAsync<BaseRequest>();
            var tradeResult = await CallAsync<BaseRequest, TradeResult>(req);
            return tradeResult.Trade.Id;
        }

        /// <summary>
        /// 获取应用订单状态
        /// </summary>
        /// <returns>订单状态</returns>
        public async Task<OrderStatus> Get_OrderStatusAsync()
        {
            pathprefix = "api";
            var req = await GetRequestTypeAsync<CallerRequest>();
            var orderStatusResult = await CallAsync<CallerRequest, OrderStatusResult>(req);
            pathprefix = "system";
            if (orderStatusResult.Errcode == "0")
            {
                return orderStatusResult.OrderStatus;
            }
            else
            {
                throw new ApiException(orderStatusResult.Errmsg);
            }
        }

        /// <summary>
        /// 获取数据源配置
        /// </summary>
        /// <returns>数据源配置</returns>
        public async Task<Datasource> Get_DatasourceAsync()
        {
            var req = await GetRequestTypeAsync<DsRequest>();
            var result = await CallAsync<DsRequest, DsResult>(req);
            return result.Datasource;
        }

        /// <summary>
        /// 批量获取数据源配置
        /// </summary>
        /// <returns>数据源配置</returns>
        public async Task<IEnumerable<Datasource>> Batch_get_DatasourceAsync()
        {
            var req = await GetRequestTypeAsync<DsListRequest>();
            var dataSourceResult = await CallAsync<DsListRequest, DsListResult>(req);
            return dataSourceResult.Datasources;
        }

    }
}
