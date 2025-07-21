using MobileAutomation.Utility;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomation
{
    public class TestBase
    {
        private AndroidDriver _driver;
        private Uri _appiumServerUrl = new Uri("http://127.0.0.1:4723");
        AppiumServiceBuilder _appiumServiceBuilder;
        AppiumLocalService appiumLocalService;
        

        [OneTimeSetUp]
        public void Setup()
        {
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.PlatformName = "Android";
            appiumOptions.DeviceName = "emulator-5554";
            appiumOptions.AutomationName = "UiAutomator2";
            appiumOptions.App = "C:\\AppiumRev\\resources\\ApiDemos-debug.apk";

            _appiumServiceBuilder = new AppiumServiceBuilder();
            appiumLocalService = _appiumServiceBuilder.WithIPAddress("127.0.0.1").UsingPort(4723).Build();
            appiumLocalService.Start();

            _driver = new AndroidDriver(_appiumServerUrl, appiumOptions);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {            

            _driver.Dispose();
            appiumLocalService.Dispose();
        }


        public AndroidDriver getDriver()
        {
            return _driver;
        }
    }
}
