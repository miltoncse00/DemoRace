using DemoRace.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRace.Common
{
    public interface IRaceContext
    {
        IRepository<Race> RaceRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Bet> BetRepository { get; }
    }
}
