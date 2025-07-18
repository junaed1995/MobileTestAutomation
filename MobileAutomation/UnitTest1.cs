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
        public void Test1()
        {
            AndroidDriver driver = getDriver();
            driver.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"OS\"]")).Click();
            Assert.Pass();
        }

        [TearDown] 
        public void TestTearDown() 
        { 
            
        }

    }
}