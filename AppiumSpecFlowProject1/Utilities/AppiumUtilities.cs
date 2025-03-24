using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;

namespace AppiumSpecFlowProject1.Utilities
{
    public class AppiumUtilities
    {
        private AppiumLocalService _appiumLocalService;
        private AndroidDriver _androidDriver;

        public AppiumUtilities(AppiumLocalService appiumLocalService, AndroidDriver androidDriver)
        {
            this._appiumLocalService = appiumLocalService;
            _androidDriver = androidDriver;
        }

        public AndroidDriver InitializeAndroidNativeApp()
        {
            var appPath = "C:\\Users\\sakum\\Downloads\\android.wdio.native.app.v1.0.8.apk";
            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723");

            var driverOptions = new AppiumOptions()
            {
                AutomationName = AutomationName.AndroidUIAutomator2,
                PlatformName = "Android",
                DeviceName = Environment.GetEnvironmentVariable("ANDROID_DEVICE") ?? "emulator-5554",
            };

            driverOptions.AddAdditionalAppiumOption("app", appPath);
            driverOptions.AddAdditionalAppiumOption("noReset", true);
            driverOptions.AddAdditionalAppiumOption("headless", true);  // Enable headless mode
            driverOptions.AddAdditionalAppiumOption("disableWindowAnimation", true);  // Disable animations for faster execution

            AndroidDriver androidDriver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
            return androidDriver;
        }

        public AndroidDriver InitializeAndroidWebApp()
        {
            var appPath = "C:\\Users\\sakum\\Downloads\\ApiDemos-debug.apk";
            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723");

            var driverOptions = new AppiumOptions()
            {
                AutomationName = AutomationName.AndroidUIAutomator2,
                PlatformName = "Android",
                DeviceName = Environment.GetEnvironmentVariable("ANDROID_DEVICE") ?? "emulator-5554",
            };

            driverOptions.AddAdditionalAppiumOption("app", appPath);
            driverOptions.AddAdditionalAppiumOption("noReset", true);
            driverOptions.AddAdditionalAppiumOption("headless", true);  // Enable headless mode
            driverOptions.AddAdditionalAppiumOption("disableWindowAnimation", true);  // Disable animations for faster execution

            AndroidDriver androidDriver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));

            List<string> allContexts = new List<string>(androidDriver.Contexts);
            foreach (var context in allContexts)
            {
                Console.WriteLine(context);
            }

            var webviewContext = allContexts.FirstOrDefault(x => x.Contains("WEBVIEW"));
            if (webviewContext != null)
            {
                androidDriver.Context = webviewContext;
            }
            else
            {
                throw new Exception("No WebView context found!");
            }

            return androidDriver;
        }

        public AppiumLocalService StartAppiumLocalService()
        {
            if (_appiumLocalService == null || !_appiumLocalService.IsRunning)
            {
                _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
                _appiumLocalService.Start();
            }
            return _appiumLocalService;
        }

        public AppiumLocalService StartAppiumLocalService(int portNumber)
        {
            if (_appiumLocalService == null || !_appiumLocalService.IsRunning)
            {
                _appiumLocalService = new AppiumServiceBuilder().UsingPort(portNumber).Build();
                _appiumLocalService.Start();
            }
            return _appiumLocalService;
        }

        public void CloseAppiumServer()
        {
            if (_appiumLocalService != null && _appiumLocalService.IsRunning)
            {
                _appiumLocalService.Dispose();
                _appiumLocalService = null;
            }
        }
    }
}
