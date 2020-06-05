using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroFeel.Finance;
using MicroFeel.Finance.Models;
using MicroFeel.Finance.Models.DbDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroFeel.YonYou.U8Api.Controllers
{
    /// <summary>
    /// 委外控制器
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OmmoController : ControllerBase
    {
        private readonly ILogger<OmmoController> _logger;
        private readonly IFinanceService _financeService;

        public OmmoController(ILogger<OmmoController> logger, IFinanceService financeService)
        {
            _logger = logger;
            _financeService = financeService;
        }

        [HttpGet]
        public PagedResult<DtoPurchaseOrder> Get()
        {
            var whs = _financeService.GetPurchaseOrders(
                "委外加工",
                "柏瑞美",
                "",
                "",
                "",
                null,
                null,
                1,
                40);
            return whs;
        }
    }
}
