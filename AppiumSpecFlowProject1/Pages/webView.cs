using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AppiumSpecFlowProject1.Pages
{
    public class webView
    {
        private AndroidDriver _driver;
        public webView(AndroidDriver androidDriver)
        {
            this._driver = androidDriver;
            PageFactory.InitElements(androidDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text=\"󰖟\"]")]
        private IWebElement webViewButton { get; set; }
        public void webClick()
        {
            webViewButton.Click();
        }
        public void webview()
        {
            List<string> AllContexts = new List<string>();
            foreach (var context in _driver.Contexts)
            {
                Console.WriteLine(context);
            }
            var driv = _driver.Contexts.First(x => x.Contains("WEBVIEW_com.wdiodemoapp"));
            _driver.Context = driv;

            IWebElement header = _driver.FindElement(By.CssSelector("#__docusaurus_skipToContent_fallback > header > div > p"));
            Console.WriteLine(header.Text);
        }
    }
}
