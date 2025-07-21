using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomation.Utility
{
    public class Utilities : TestBase
    {

        public static void TakeScreenShot(AndroidDriver androidDriver,string screenshotName)
        {
            ITakesScreenshot takesScreenshot = androidDriver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            screenshot.SaveAsFile($"C:\\AppiumRev\\MobileAutomation\\Screenshots\\{screenshotName+"_"+ getCurrentDateTimeStamp()}.png");
        }

        public static string getCurrentDateTimeStamp()
        {
            string dateTimeFormat = DateTime.Now.ToString("dd_MMM_yyyy_HH_mm_ss");
            Console.WriteLine(dateTimeFormat);
            return dateTimeFormat;
        }
    }
}
