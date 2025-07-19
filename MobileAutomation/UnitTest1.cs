using MobileAutomation.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace MobileAutomation
{
    [TestFixture]
    public class Tests : TestBase
    {


        [SetUp]
        public void TestSetup()
        {
            
        }

        [Test]
        public void ClickOSText()
        {
            AndroidDriver driver = getDriver();
            HomePage homePage = new HomePage(driver);
            homePage.ClickOnListOption("OS");
            Assert.Pass();
        }

        [TearDown] 
        public void TestTearDown() 
        { 
            
        }

    }
}