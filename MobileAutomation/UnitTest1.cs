using AventStack.ExtentReports;
using MobileAutomation.PageObjects;
using MobileAutomation.Utility;
using NUnit.Framework.Interfaces;

namespace MobileAutomation
{
    [TestFixture]
    public class Tests : TestBase
    {
        private TestContext? testContext;
        private static AventStack.ExtentReports.ExtentReports _extent;
        private ExtentTest _test; // Non-static, as it represents an individual test case
        private AdvancedGestures _advancedGestures;

        [SetUp]
        public void TestSetup()
        {
            testContext = TestContext.CurrentContext;            
        }

        [Test]
        public void ClickOnSensorOption() {

            var driver = getDriver();
            HomePage homePage = new HomePage(driver);   
            homePage.ClickOnListOption("OS");
            OsOptionPage osOptionPage = new OsOptionPage(driver);
            osOptionPage.TapOnSensorOptionWhenAvailable();
        }

        [Test]
        public void NavigateAndOpenMorseCodeOption()
        {
            var driver = getDriver();   
            HomePage homePage = new HomePage(driver);
            homePage.ClickOnListOption("OS");
            OsOptionPage osOptionPage = new OsOptionPage(driver);
            osOptionPage.TapOnMorseCodeOption();
        }

        [Test]
        public void ClickOnViewsAndScrollToPicker()
        {
            var driver = getDriver();
            HomePage homePage = new HomePage(driver);
            homePage.ClickOnListOption("Views");
            ViewsPage viewsPage = new ViewsPage(driver);

            _advancedGestures = new AdvancedGestures(driver);
            _advancedGestures.SwipeDownToScrollUp(driver,80.00,50.00);

            Assert.That(viewsPage.IsPickerVisible(), "Picker Option is displayed");
        }

        [Test]
        public void NavigateFromHomePageToSearchViewOptionAndClick()
        {
            var driver = getDriver();
            HomePage homePage = new HomePage(driver);
            homePage.ClickOnListOption("Views");
            ViewsPage viewsPage = new ViewsPage(driver);

            viewsPage.ClickOnSearchView();
        }

        [TearDown] 
        public void TestTearDown() 
        {
            if (testContext?.Result.Outcome.Status == TestStatus.Failed)
            {
                Utilities.TakeScreenShot(getDriver(), "ssName");
            }
        }

    }
}