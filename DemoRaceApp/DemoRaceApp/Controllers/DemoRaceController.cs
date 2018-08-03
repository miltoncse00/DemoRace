using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoRace.Common;
using DemoRace.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoRaceApp.Controllers
{
    [Route("api/DemoRace")]
    [ApiController]
    public class DemoRaceController : ControllerBase
    {
        private readonly IRaceBusiness raceBusiness;

        public DemoRaceController(IRaceBusiness raceBusiness)
        {
            this.raceBusiness = raceBusiness;
        }

        [Route("CustomerBetsSummary")]
        [HttpGet]
        [Produces("application/json", Type = typeof(CustomerBetSummary))]
        public async Task<IActionResult> GetCustomerSummary()
        {
           var customerBetSummary = await raceBusiness.GetCustomerBetsSummary();

            return Ok(customerBetSummary);
        }

        [Route("RaceSummary")]
        [HttpGet]
        [Produces("application/json", Type = typeof(RaceSummary))]
        public async Task<IActionResult> GetRaceSummary()
        {
            var raceSummaries = await raceBusiness.GetRaceSummary();

            return Ok(raceSummaries);
        }
    }
}