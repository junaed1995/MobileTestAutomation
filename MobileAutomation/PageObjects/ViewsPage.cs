using MobileAutomation.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomation.PageObjects
{
    [TestFixture]
    public class ViewsPage : BasePage
    {
        AdvancedGestures advancedGestures;
        public ViewsPage(AppiumDriver driver) : base(driver) 
        {
            advancedGestures = new AdvancedGestures(driver);
        }

        private const string pickerXpath = "//android.widget.TextView[@content-desc=\"Picker\"]";
        private const string searchViewXpath = "//android.widget.TextView[@content-desc=\"Search View\"]";
        private const string galleryViewXpath = "//android.widget.TextView[@content-desc=\"Gallery\"]";

        [FindsBy(How =How.XPath, Using=pickerXpath)]
        private IWebElement _pickerElement;

        [FindsBy(How =How.XPath, Using= searchViewXpath)]
        private IWebElement _searchViewElement;

        [FindsBy(How =How.XPath, Using= galleryViewXpath)]
        private IWebElement _galleryOption;

        public bool IsPickerVisible()
        {
           return _pickerElement.Displayed;
        }

        public void ClickOnSearchView() 
        {            
            advancedGestures.SwipeToElement(_driver, _searchViewElement);
            _searchViewElement.Click();
        }

        public void ClickOnGallery()
        {
            _galleryOption.Click();
        }
    }
}
