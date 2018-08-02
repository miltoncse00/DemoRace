using DemoRace.Common;
using DemoRace.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRace.Test
{
    [TestClass]
    class DemoTests
    {
        IRaceContext context;
        [TestInitialize]
        public void Init()
        {
            context = new RaceApiContext();
        }

        [TestMethod]
        public void CheckApiCall()
        {
            var a = false;
            Assert.IsTrue(a);
        
        }
    }
}
