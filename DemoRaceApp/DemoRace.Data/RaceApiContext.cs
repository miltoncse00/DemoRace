using DemoRace.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRace.Data
{
    public class RaceApiContext:IRaceContext
    {
        private const string customersUrl = "https://whatech-customerbets.azurewebsites.net/api/GetCustomers?name=Syed";
        private const string betsUrl = "https://whatech-customerbets.azurewebsites.net/api/GetBetsV2?name=Syed";
        private const string raceUrl = "https://whatech-customerbets.azurewebsites.net/api/GetRaces?name=Syed";

        public RaceApiContext()
        {
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            CustomerRepository = new ApiRepository<Customer>(customersUrl);
            RaceRepository = new ApiRepository<Race>(raceUrl);
            BetRepository = new ApiRepository<Bet>(betsUrl);
        }

        public IRepository<Customer> CustomerRepository { get; private set; }
        public IRepository<Race> RaceRepository { get; private set; }
        public IRepository<Bet> BetRepository { get;  private set; }
    }
}
