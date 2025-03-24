using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppiumSpecFlowProject1.Hooks;
using AppiumSpecFlowProject1.Pages;
using NUnit.Framework;

namespace AppiumSpecFlowProject1.TestSuite
{
    [TestFixture]
    public class WebDriverIO:TestInitialize
    {
        static Login lg = new Login(AndroidContext);
        [Test]
        public void TestClick()
        {
            lg.ClickLogin();
            lg.ClickSignUp();
            lg.SendEmail();
            lg.SendPass();
            lg.finalSignUp();        
            lg.alertAccept();

            lg.loginbutton();
            lg.alertAccept();
        }

    }
}
