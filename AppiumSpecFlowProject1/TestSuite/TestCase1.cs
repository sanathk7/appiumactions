using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppiumSpecFlowProject1.Pages;
using NUnit.Framework;
using AppiumSpecFlowProject1.Hooks;

namespace AppiumSpecFlowProject1.TestSuite
{
    [TestFixture]
    public class TestCase1:TestInitialize
    {
        static ClickPage cp = new ClickPage(AndroidContext);
        [Test]
        public void TestClick()
        {
            cp.ClickViews();
            cp.HandlingRadioCheckboxes();
        }
    }
}
