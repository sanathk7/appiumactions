using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace AppiumSpecFlowProject1.Pages
{
    public class Login
    {
        private AndroidDriver androidDriver; // Store androidDriver

        public Login(AndroidDriver androidDriver)
        {
            this.androidDriver = androidDriver; 
            PageFactory.InitElements(androidDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text=\"󰍂\"]")]
        private IWebElement LoginButton1 { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text=\"Sign up\"]")]
        private IWebElement SignUpButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@content-desc=\"input-email\"]")]
        private IWebElement email { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@content-desc=\"input-password\"]")]
        private IWebElement pass { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@content-desc=\"input-repeat-password\"]")]
        private IWebElement confpass { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text=\"SIGN UP\"]")]
        private IWebElement finSignup { get; set; }


        [FindsBy(How = How.XPath, Using = "(//android.widget.TextView[@text=\"Login\"])[1]")]
        private IWebElement login1 { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@content-desc=\"input-email\"]")]
        private IWebElement email1 { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@content-desc=\"input-password\"]")]
        private IWebElement pass1 { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@content-desc=\"button-LOGIN\"]/android.view.ViewGroup")]
        private IWebElement loginbutton1 { get; set; }
        public void clicking(IWebElement elem)
        {
            elem.Click();
        }
        
        public void ClickLogin()
        {

            LoginButton1.Click();
        }
        public void ClickSignUp()
        {
            SignUpButton.Click();
        }
        public void SendEmail()
        {
            email.Click();
            email.SendKeys("abc@gmail.com");
        }
        public void SendPass()
        {
            pass.Click();
            pass.SendKeys("1234567890");
            confpass.Click();
            confpass.SendKeys("1234567890");
        }
        public void finalSignUp()
        {
            finSignup.Click();
        }
        public void alertAccept()
        {
            try
            {
                new WebDriverWait(androidDriver, TimeSpan.FromSeconds(5))
                    .Until(driver => driver.SwitchTo().Alert()) // Wait for the alert
                    .Accept(); // Accept the alert
                Console.WriteLine("alert Accepted");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("No alert found.");
            }
        }
        public void loginbutton()
        {
            login1.Click();
            email1.Click();
            email1.SendKeys("abc@gmail.com");
            pass1.Click();
            pass1.SendKeys("1234567890");
            loginbutton1.Click();

        }

    }
}
