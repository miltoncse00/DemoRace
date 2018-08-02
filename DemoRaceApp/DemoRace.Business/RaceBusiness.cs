using DemoRace.Common;
using DemoRace.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRace.Business
{
    public class RaceBusiness : IRaceBusiness
    {
        private readonly IRaceContext context;

        public RaceBusiness(IRaceContext context)
        {
            this.context = context;
        }

        public async Task<RaceSummary> GetRaceSummary()
        {
            var summary = new RaceSummary();

            return await Task.Run(() => summary);
        }
    }
}
