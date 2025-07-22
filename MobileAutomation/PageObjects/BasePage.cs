using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MobileAutomation.PageObjects
{
    public class BasePage 
    {
        protected AppiumDriver _driver;
        WebDriverWait wait ;

        public BasePage(AppiumDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);           
        }

        public void WaitForElementToBeVisible(int seconds, string locatorType,string locatorValue)
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            switch (locatorType)
            {
                case "Id":
                    wait.Until(ExpectedConditions.ElementIsVisible(ByAccessibilityId.Id(locatorValue)));
                    break;
                case "xpath":
                    wait.Until(ExpectedConditions.ElementIsVisible(ByAccessibilityId.XPath(locatorValue)));
                    break;
                case "classname":
                    wait.Until(ExpectedConditions.ElementIsVisible(ByAccessibilityId.ClassName(locatorValue)));
                    break;
                default:
                    Console.WriteLine("Suitable locator not found");
                    break;
            }
        }

    }
}
