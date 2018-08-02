using DemoRace.Common;
using DemoRace.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<IList<CustomerSummary>> GetCustomerSummary()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<RaceSummary>> GetRaceSummary()
        {
            var raceSummaries = new List<RaceSummary>();
            var races = await context.RaceRepository.GetAll();
            var bets = await context.BetRepository.GetAll();
            if (races != null && races.Count > 0)
                foreach (var race in races)
                {
                    var raceBets = bets.Where(b => b.RaceId == race.Id);
                    var raceSummary = new RaceSummary();
                    raceSummary.Status = race.Status;
                    raceSummary.Stake = raceBets.Sum(s => s.Stake);
                    var horseIdBetCountMap = raceBets.GroupBy(s => s.HorseId).ToDictionary(s => s.Key, s => new { BetCount = s.Count(), TotalStake = s.Sum(b => b.Stake) });
                    raceSummary.Hourses = new List<HorseSummary>();
                    foreach (var horse in race.Horses)
                    {
                        var horseSummary = new HorseSummary();
                        horseSummary.Id = horse.Id;
                        horseSummary.Name = horse.Name;

                        if (horseIdBetCountMap.ContainsKey(horse.Id))
                        {
                            var betValue = horseIdBetCountMap[horse.Id];
                            horseSummary.BetCount = betValue.BetCount;
                            //Consider the formually that Payout will be Stake for all customer * odds
                            horseSummary.PayOut = betValue.TotalStake * horse.Odds;
                        }
                        else
                        {
                            horseSummary.BetCount = 0;
                            horseSummary.PayOut = 0;
                        }
                        raceSummary.Hourses.Add(horseSummary);
                    }

                    raceSummaries.Add(raceSummary);
                }
            return raceSummaries;
        }
    }
}
