using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interactions;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace AppiumSpecFlowProject1.Pages
{
    public class ClickPage
    {
        private AndroidDriver _driver;
        public ClickPage(AndroidDriver androidDriver)
        {
            this._driver = androidDriver;
            PageFactory.InitElements(androidDriver, this);

        }

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@content-desc=\"Views\"]")]
        private IWebElement Views { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView")]
        private IWebElement elements { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@content-desc=\"Radio Group\"]")]
        private IWebElement radio { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.RadioButton[@content-desc=\"Dinner\"]")]
        private IWebElement dinner { get; set; }
        


        public void ClickViews()
        {

            Views.Click();
        }

        public void HandlingRadioCheckboxes()
        {
            ActionBuilder actionBuilder = new ActionBuilder();
            var touch = new OpenQA.Selenium.Appium.Interactions.PointerInputDevice(PointerKind.Touch, "finger");


            IList<AppiumElement> elements = _driver.FindElements(MobileBy.ClassName("android.widget.TextView"));
            var origin = elements[13];
            var loc1 = origin.Location;
            var target = elements[1];
            var loc2 = target.Location;
            actionBuilder.ClearSequences();

            //move to element
            actionBuilder.AddAction(touch.CreatePointerMove(origin, 0, 0, TimeSpan.FromMilliseconds(800)));

            //touch to element
            actionBuilder.AddAction(touch.CreatePointerDown(PointerButton.TouchContact));
            actionBuilder.AddAction(touch.CreatePause(TimeSpan.FromMilliseconds(800)));
            actionBuilder.AddAction(touch.CreatePointerMove(target, 0, 0, TimeSpan.FromMilliseconds(800)));
            actionBuilder.AddAction(touch.CreatePointerUp(PointerButton.TouchContact));

            var sequenceActions = actionBuilder.ToActionSequenceList();
            _driver.PerformActions(sequenceActions);

            //radio.Click();
            IWebElement RadioGroup = _driver.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"Radio Group\"]"));
            RadioGroup.Click();
            IWebElement DinnerRadio = _driver.FindElement(By.XPath("//android.widget.RadioButton[@content-desc=\"Dinner\"]"));
            dinner.Click();
        }
    }
}
//android.widget.TextView[@content-desc="Radio Group"]