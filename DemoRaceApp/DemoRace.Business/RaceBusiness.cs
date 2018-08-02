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

        public async Task<IList<RaceSummary>> GetRaceSummary()
        {
            var raceSummaries = new List<RaceSummary>();
            var races = await context.RaceRepository.GetAll();
            if (races != null && races.Count > 0)
                foreach (var race in races)
                {
                    var raceSummary = new RaceSummary();
                    raceSummary.Status = race.Status;
                    raceSummaries.Add(raceSummary);
                }
            return raceSummaries;
        }
    }
}
