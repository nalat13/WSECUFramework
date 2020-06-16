using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSECUFramework.Utilities
{
    public class ElementMethods
    {
        IWebDriver driver;
        ExtentTest test;

        public ElementMethods(IWebDriver driver, ExtentTest test)
        {
            this.driver = driver;
            this.test = test;
        }

        public void EnterText(IWebElement element, string text)
        {
            try
            {
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                //test.Fail("Enter text failed.");
                CaptureScreenshotOnFailures("EnterText - Value is not entered.");
                throw (e);
            }
        }

        public void ClickSubmit(IWebElement element)
        {
            try
            {
                element.Submit();
            }
            catch (Exception e)
            {
                //test.Fail("Click Submit button failed.");
                CaptureScreenshotOnFailures("ClickSubmit - Element is not clickable.");
                throw (e);
            }
        }

        public void CaptureScreenshotOnFailures(String message)
        {
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string image = file.AsBase64EncodedString;
            test.Fail(message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }

}

