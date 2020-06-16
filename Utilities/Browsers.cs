using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace WSECUFramework.Utilities
{
    public class Browsers
    {
        private static IWebDriver webDriver;
        private static string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        private static string actualPath = path.Substring(0, path.LastIndexOf("bin"));
        private static string projectPath = new Uri(actualPath).LocalPath;
        private static string driverPath = projectPath + "Resources";

        public static IWebDriver SelectBrowser(String browser)
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver(driverPath);
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                default:
                    Assert.Fail("Driver not found.");
                    break;
            }
            webDriver.Manage().Window.Maximize();
            return webDriver;
        }
    }
}
