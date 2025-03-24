using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Android;


namespace AppiumSpecFlowProject1.Utilities
{
    public class Base
    {
        public AppiumLocalService AppiumServiceContext;
        public static AndroidDriver AndroidContext;

        public AppiumUtilities AppiumUtilities => new AppiumUtilities(AppiumServiceContext, AndroidContext);
        public AndroidDriver StartAppiumServerForHybrid()
        {
            AppiumServiceContext = AppiumUtilities.StartAppiumLocalService();
            AndroidContext = AppiumUtilities.InitializeAndroidNativeApp();
            return AndroidContext;
        }
    }
}
