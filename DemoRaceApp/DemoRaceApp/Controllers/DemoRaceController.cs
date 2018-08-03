using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoRace.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoRaceApp.Controllers
{
    [Route("api/[DemoRace]")]
    [ApiController]
    public class DemoRaceController : ControllerBase
    {
        private readonly IRaceBusiness raceBusiness;

        public DemoRaceController(IRaceBusiness raceBusiness)
        {
            this.raceBusiness = raceBusiness;
        }

        [Route("CustomerSummary")]
        [HttpGet]
        public async Task<IActionResult> GetCustomerSummary()
        {
           var customerSummary = await raceBusiness.GetCustomerBetsSummary();

            return Ok(customerSummary);
        }
    }
}