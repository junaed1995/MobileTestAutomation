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

        public enum SwipeDirection{
            Up, Down, Left, Right
        }
        
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

        public void SwipeToElement(AppiumDriver driver,IWebElement SwipeToWhichElement,int SwipeLimit =3)
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

        public void SwipeLeftOrRight(AppiumDriver driver, double swipeAmount,int SwipeLimit = 3,SwipeDirection direction = SwipeDirection.Left,IWebElement StartElementScroll = null)
        {
            Size screenSize = driver.Manage().Window.Size;
            int centerY = screenSize.Height / 10;
            double SwipeInterval = 100;
            

            if (direction == SwipeDirection.Left)
            {

                int startX = (int)(screenSize.Width * 0.8);

                int endX = (int)(screenSize.Width * (0.8 - swipeAmount));

                

                for(int i = 1;i<=SwipeLimit;i++)
                {
                    Actions actions = new Actions(driver);
                    actions.MoveToLocation(startX, centerY)
                        .ClickAndHold()
                        .Pause(TimeSpan.FromMilliseconds(SwipeInterval))
                        .MoveToLocation(endX, centerY)
                        .Release()
                        .Perform();
                }
            }
            else
            {
                int startX = (int)(screenSize.Width * 0.2);

                int endX = (int)(screenSize.Width * (0.2 + swipeAmount));

                

                for (int i = 1; i <= SwipeLimit; i++)
                {
                    Actions actions = new Actions(driver);
                    actions.MoveToLocation(startX, centerY)
                        .ClickAndHold()
                        .Pause(TimeSpan.FromMilliseconds(SwipeInterval))
                        .MoveToLocation(endX, centerY)
                        .Release()
                        .Perform();
                }
            }
        }

        public void ScrollFromElement(IWebElement element,AppiumDriver driver, double swipeAmount, int SwipeLimit = 3, SwipeDirection direction = SwipeDirection.Left)
        {
            Point elementLocation = element.Location;
            int elementScrollY = elementLocation.Y;
            SwipeLeftOrRight(driver,swipeAmount,SwipeLimit, direction, element);
        }
    }
}
