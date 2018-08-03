using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DemoRace.Common
{
    public class CustomerBetSummary
    {
        public IList<CustomerSummary> CustomerSummaries { get; set; }

        [Description("Total bet amount")]
        public decimal TotalBets { get; set; }
    }
}
