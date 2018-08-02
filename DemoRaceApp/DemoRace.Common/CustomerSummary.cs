using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRace.Common
{
    public class CustomerSummary:Customer
    {
        public int BetCount { get; set; }
        public decimal BestAmount { get; set; }
        public bool RiskIndicator { get; set; }
    }
}
