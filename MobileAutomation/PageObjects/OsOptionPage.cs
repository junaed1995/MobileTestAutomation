using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomation.PageObjects
{
    public class OsOptionPage : BasePage
    {
        //AndroidDriver driver;

        public OsOptionPage(AppiumDriver driver) : base(driver)
        {
            
        }

        private const string SensorOptionXpath = "//android.widget.TextView[@content-desc=\"Sensors\"]";
        private const string MorseCodeOptionXpath = "//android.widget.TextView[@content-desc=\"Morse Code\"]";


        [FindsBy(How = How.XPath, Using = MorseCodeOptionXpath)]
        private IWebElement _morseCode;

        [FindsBy(How = How.XPath, Using = SensorOptionXpath)]
        private IWebElement _sensorOption;

        public void TapOnMorseCodeOption()
        {
            _morseCode.Click();
        }

        public void TapOnSensorOptionWhenAvailable()
        {
            WaitForElementToBeVisible(3,"xpath", SensorOptionXpath);
            _sensorOption.Click();
        }


    }
}
