using MobileAutomation.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SeleniumExtras.PageObjects;
using static MobileAutomation.Utility.AdvancedGestures;


namespace MobileAutomation.PageObjects
{
    public class PhotosPage : BasePage
    {
        AppiumDriver driver;
        AdvancedGestures advancedGestures;
        public PhotosPage(AppiumDriver driver) : base(driver)
        {
            advancedGestures = new AdvancedGestures(driver);
        }

        private const string imageListClass = "android.widget.ImageView";
        private const string firstVisibleImage = "//android.widget.Gallery[@resource-id=\"io.appium.android.apis:id/gallery\"]/android.widget.ImageView[1]";

        [FindsBy(How=How.ClassName,Using = imageListClass)]
        private IList<IWebElement> _visibleImageList;

        [FindsBy(How=How.XPath,Using = firstVisibleImage)]
        private IWebElement _firstVisibleImage;

        public void HighlightVisibleImageBasedOnIndex(AppiumDriver driver,int index,double swipeAmt,int scrollHowManyTimes = 3, SwipeDirection swipeDirection=SwipeDirection.Left)
        {
            if (scrollHowManyTimes > 0) {
                advancedGestures.ScrollFromElement(_firstVisibleImage, driver, swipeAmt,scrollHowManyTimes, SwipeDirection.Left);                
            }
            _visibleImageList[index].Click();
        }
    }
}
