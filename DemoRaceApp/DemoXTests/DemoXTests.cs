using DemoRace.Common;
using DemoRace.Data;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using DemoRace.Common.Interfaces;
using DemoRace.Business;
using System.Linq;

namespace DemoXTests
{

    public class DemoXTests
    {
        IRaceContext context;
        IRaceBusiness raceBusiness;
        List<Customer> customers = new List<Customer>();
        List<Race> races = new List<Race>();
        List<Bet> bets = new List<Bet>();

        public DemoXTests()
        {
            var mock = new Mock<IRaceContext>();
            mock.Setup(x => x.CustomerRepository).Returns(new FakeRepository<Customer>(customers));

            mock.Setup(x => x.BetRepository).Returns(new FakeRepository<Bet>(bets));
            mock.Setup(x => x.RaceRepository).Returns(new FakeRepository<Race>(races));

            context = mock.Object;
            raceBusiness = new RaceBusiness(context);
        }
        [Fact]
        public async void SetUpIntialTestData()
        {
            await SetUpIntialTestData1();

        }

        [Fact]
        public async void CheckStatusOfRaceWithIntialSetupShouldBeCompletedAndDetails()
        {
            await SetUpIntialTestData1();
            var summaries = await raceBusiness.GetRaceSummary();
            summaries.First().Status.Should().Be(RaceStatus.Completed.ToString());
            summaries.First().Stake.Should().Be(250 );
            summaries.First().Hourses.Count.Should().Be(2);
            summaries.First().Hourses[0].BetCount.Should().Be(1);
            summaries.First().Hourses[0].PayOut.Should().Be(150);

        }


        [Fact]
        public async void CheckCustomerBetSummaryWithCustomerCount2andDetails()
        {
            await SetUpIntialTestData2();
            var summary = await raceBusiness.GetCustomerBetsSummary();
            summary.CustomerSummaries.Count.Should().Be(2);
            summary.CustomerSummaries[0].BetCount.Should().Be(2);
            summary.CustomerSummaries[0].BetAmount.Should().Be(250);
            summary.CustomerSummaries[0].RiskIndicator.Should().Be(true);
            summary.TotalBetValue.Should().Be(250);
        }


        private async System.Threading.Tasks.Task SetUpIntialTestData1()
        {
            customers.Clear();
            PopulateCustomer1();
            var actualCustomers = await context.CustomerRepository.GetAll();
            actualCustomers.Count.Should().Be(2);
            actualCustomers[0].Name.Should().Be("Rob");
            bets.Clear();
            PopulateBet1();
            var actualBets = await context.BetRepository.GetAll();
            actualBets.Count.Should().Be(2);
            actualBets[0].Stake.Should().Be(100);
            races.Clear();
            PopulateRaces1();
            var actualRaces = await context.RaceRepository.GetAll();
            actualRaces.Count.Should().Be(1);
            actualRaces[0].Horses.Count.Should().Be(2);
            actualRaces[0].Horses[0].Odds.Should().Be(1.5M);
        }

        private async System.Threading.Tasks.Task SetUpIntialTestData2()
        {
            customers.Clear();
            PopulateCustomer1();
            var actualCustomers = await context.CustomerRepository.GetAll();
            actualCustomers.Count.Should().Be(2);
            actualCustomers[0].Name.Should().Be("Rob");
            bets.Clear();
            PopulateBet2();
            var actualBets = await context.BetRepository.GetAll();
            actualBets.Count.Should().Be(2);
            actualBets[0].Stake.Should().Be(100);
            races.Clear();
            PopulateRaces1();
            var actualRaces = await context.RaceRepository.GetAll();
            actualRaces.Count.Should().Be(1);
            actualRaces[0].Horses.Count.Should().Be(2);
            actualRaces[0].Horses[0].Odds.Should().Be(1.5M);
        }

        private void PopulateCustomer1()
        {
            customers.Add(new Customer() { Id = 1, Name = "Rob" });
            customers.Add(new Customer() { Id = 3, Name = "Mark" });
        }

        private void PopulateBet1()
        {
            bets.Add(new Bet() { CustomerId = 1, HorseId = 1, RaceId = 1, Stake = 100, Won = true });
            bets.Add(new Bet() { CustomerId = 3, HorseId = 2, RaceId = 1, Stake = 150, Won = true });
        }


        private void PopulateBet2()
        {
            bets.Add(new Bet() { CustomerId = 1, HorseId = 1, RaceId = 1, Stake = 100, Won = true });
            bets.Add(new Bet() { CustomerId = 1, HorseId = 2, RaceId = 1, Stake = 150, Won = true });
        }

        private void PopulateRaces1()
        {
            races.Add(new Race()
            {
                Id = 1,
                Name = "R1",
                Start = DateTime.Now.AddDays(-1),
                Status = RaceStatus.Completed.ToString(),
                Horses = new List<Horse>
            {
                new Horse(){ Id = 1, Name="Little Orange", Odds= 1.5M },
                new Horse(){ Id=2 , Name="Big Orange", Odds=5.5M}
            }
            });
            //races.Add(new Bet() { CustomerId = 3, HorseId = 2, RaceId = 1, Stake = 150, Won = true });
        }

    }
}
