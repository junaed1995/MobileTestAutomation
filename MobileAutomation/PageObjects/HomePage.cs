using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Appium;

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
            Console.WriteLine(_listElement.Count);
            foreach (var element in _listElement)
            {
                try
                {
                    if (element.GetAttribute("content-desc").ToLower().Equals(option.ToLower()))
                    {
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
