using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRace.Common
{
    public class CustomerBetSummary
    {
        public IList<CustomerSummary> CustomerSummaries { get; set; }
        public decimal TotalBets { get; set; }
    }
}
