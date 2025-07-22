using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MobileAutomation.PageObjects
{
    public class HomePage : BasePage
    {        

        public HomePage(AppiumDriver driver) : base(driver)
        {
            //_driver = driver;
            //PageFactory.InitElements(_driver, this);
            
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
                        WaitForElementToBeVisible(5,"className",PageListClassName);                       
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
