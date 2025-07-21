using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MobileAutomation.PageObjects
{
    public class HomePage
    {
        protected AndroidDriver _driver;

        public HomePage(AndroidDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            
        }

        private const string PageListClassName = "android.widget.TextView";


        [FindsBy(How =How.ClassName,Using = PageListClassName)]
        private IList<IWebElement> _listElement 
        { 
          get; 
          set; 
        }

        public void ClickOnListOption(string option)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            Console.WriteLine(_listElement.Count);
            foreach (var element in _listElement)
            {
                try
                {
                    if (element.GetAttribute("content-desc").ToLower().Equals(option.ToLower()))
                    {
                        webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(PageListClassName)));
                        element.Click();
                        break;
                    }
                        
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}
