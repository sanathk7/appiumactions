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
    public class WebDriverWebView:TestInitialize
    {
        static webView wv = new webView(AndroidContext);
        [Test]
        public void TestClick()
        {
            wv.webClick();
            wv.webview();
        }
    }
}
