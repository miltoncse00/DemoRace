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
        private const decimal RiskIndicatorThresold = 200;
        public RaceBusiness(IRaceContext context)
        {
            this.context = context;
        }

        public  async Task<CustomerBetSummary> GetCustomerBetsSummary()
        {
            var customerbetsSummary = new CustomerBetSummary();
            customerbetsSummary.CustomerSummaries = new List<CustomerSummary>();
            var customers = await context.CustomerRepository.GetAll();
            var bets = await context.BetRepository.GetAll();
            var customerBets = (from customer in customers
                                join bet in bets
                                on customer.Id equals bet.CustomerId
                                group bet by bet.CustomerId into customerbetGroup
                                select customerbetGroup).ToDictionary(g => g.Key, g => new { BetCount = g.Count(), BetAmount = g.Sum(s => s.Stake) });
            decimal totalBets = 0;         
                              
            foreach (var customer in customers)
            {
                var customerSummary = new CustomerSummary();
                customerSummary.Id = customer.Id;
                customerSummary.Name = customer.Name;                
                if(customerBets.ContainsKey(customer.Id))
                {
                    customerSummary.BetCount = customerBets[customer.Id].BetCount;
                    customerSummary.BetAmount = customerBets[customer.Id].BetAmount;
                    customerSummary.RiskIndicator = customerSummary.BetAmount > RiskIndicatorThresold;
                    totalBets += customerSummary.BetAmount;
                }
                customerbetsSummary.CustomerSummaries.Add(customerSummary);
            }
            customerbetsSummary.TotalBetValue = totalBets;
            return customerbetsSummary;
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
                            //Consider the formula that Payout will be Stake for all customer * odds
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
