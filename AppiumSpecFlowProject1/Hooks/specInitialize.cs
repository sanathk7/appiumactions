using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppiumSpecFlowProject1.Utilities;
using NUnit.Framework;

namespace AppiumSpecFlowProject1.Hooks
{
    [Binding]
    public partial class specInitialize:Base
    {
        [BeforeScenario]
        public void TestInitializeTest()
        {
            AndroidContext = StartAppiumServerForHybrid();
            ScenarioContext.Current["androidContext"] = AndroidContext;
        }
        [AfterScenario]
        public void CleanUp()
        {
            AppiumUtilities.CloseAppiumServer();
        }
    }
}
