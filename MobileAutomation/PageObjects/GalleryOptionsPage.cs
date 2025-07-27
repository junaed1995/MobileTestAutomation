using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SeleniumExtras.PageObjects;


namespace MobileAutomation.PageObjects
{
    public class GalleryOptionsPage : BasePage
    {
        AppiumDriver driver;
        public GalleryOptionsPage(AppiumDriver driver) : base(driver) {
        
            this.driver = driver;
        }

        private const string listXpath = "//android.widget.ListView//android.widget.TextView";

        [FindsBy(How = How.XPath, Using = listXpath)]
        private IList<IWebElement> _galleryOptionList;

        public void OpenGalleryType(int index=0)
        {
            _galleryOptionList[index].Click();
        }

    }
}
