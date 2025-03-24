using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppiumSpecFlowProject1.Utilities;
using NUnit.Framework;

namespace AppiumSpecFlowProject1.Hooks
{
    [TestFixture]

    public class TestInitialize:Base
    {
        [SetUp]
        public void TestInitializeTest()
        {
            AndroidContext = StartAppiumServerForHybrid();
        }
        public void CleanUp()
        {
            AppiumUtilities.CloseAppiumServer();
        }
    }
}
