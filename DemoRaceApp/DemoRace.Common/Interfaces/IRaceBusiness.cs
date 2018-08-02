using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRace.Common.Interfaces
{
    public interface IRaceBusiness
    {
       Task<IList<RaceSummary>> GetRaceSummary();
    }
}
