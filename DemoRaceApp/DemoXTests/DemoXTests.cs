using DemoRace.Common;
using DemoRace.Data;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DemoXTests
{

    public class DemoXTests
    {
        IRaceContext context;
        List<Customer> customers = new List<Customer>();
        List<Race> races = new List<Race>();
        List<Bet> bets= new List<Bet>();

        public DemoXTests()
        {
            var mock = new Mock<IRaceContext>();
            mock.Setup(x => x.CustomerRepository).Returns(new FakeRepository<Customer>(customers));

            mock.Setup(x => x.BetRepository).Returns(new FakeRepository<Bet>(bets));
            mock.Setup(x => x.RaceRepository).Returns(new FakeRepository<Race>(races));

            context = mock.Object;
        }
        [Fact]
        public async void Test1()
        {
            var data = await context.RaceRepository.GetAll();

            Assert.True(data.Count > 0);
        }
    }
}
