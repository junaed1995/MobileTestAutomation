using OpenQA.Selenium.Appium.Android;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace MobileAutomation.Utility
{
    public class AdvancedGestures : TestBase
    {

        AppiumDriver _driver;
        
        public AdvancedGestures(AppiumDriver driver)
        {
            _driver = driver;
        }

        public void SwipeDownToScrollUp(AppiumDriver driver,double startPercentage,double EndPercentage)
        {
            Size screen = driver.Manage().Window.Size;
            int screenWidth = screen.Width;
            int screenHeight = screen.Height;

            // Calculate start and end points for a vertical swipe UP
            // Start near the bottom (e.g., 80% from top)

            int StartY =(int) ((startPercentage/100) * screenHeight);
            int EndY =(int) ((EndPercentage/100) * screenHeight);

            int ScreenCenter = (int)screenWidth / 2;

            Actions actions = new Actions(driver);

            actions.MoveToLocation(ScreenCenter, StartY)
                .ClickAndHold()
                .Pause(TimeSpan.FromMilliseconds(500))
                .MoveToLocation(ScreenCenter, EndY)
                .Release().Perform();
        }

        public void SwipeToElement(AppiumDriver driver,IWebElement SwipeToWhichElement,int SwipeLimit=3)
        {
            for (int i = 0; i < SwipeLimit; i++)
            {
                try
                {
                    if (SwipeToWhichElement.Displayed)
                        break;

                }
                catch (NoSuchElementException e)
                {
                    
                }

                SwipeDownToScrollUp(driver, 80.00, 50.00);
            }
        }
    }
}
