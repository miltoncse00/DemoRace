using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DemoRace.Common
{
    public enum RaceStatus
    {
        [Description("completed")]
        Completed=0,
        [Description("inprogress")]
        InProgress=1,
        [Description("pending")]
        pending=2
    }
}
