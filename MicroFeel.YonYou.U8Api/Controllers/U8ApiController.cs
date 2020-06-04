using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroFeel.Finance;
using MicroFeel.Finance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroFeel.YonYou.U8Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class U8ApiController : ControllerBase
    {
        private readonly ILogger<U8ApiController> _logger;
        private readonly IFinanceService _financeService;

        public U8ApiController(ILogger<U8ApiController> logger,IFinanceService financeService)
        {
            _logger = logger;
            _financeService = financeService;
        }

        [HttpGet]
        public Dictionary<string,string> Get()
        {
            var whs = _financeService.GetWarehouses();
            return whs;
        }
    }
}
