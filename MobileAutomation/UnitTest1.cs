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