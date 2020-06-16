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
        public static IWebDriver SelectBrowser(String browser)
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "Edge":
                    webDriver = new EdgeDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
            return webDriver;
        }
    }
}
