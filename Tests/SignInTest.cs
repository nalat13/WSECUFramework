using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WSECUFramework.Pages;
using WSECUFramework.Utilities;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WSECUFramework.Tests
{
    class SignInTest
    {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void StartReport()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            //Report location
            string reportpath = projectPath + "Reports\\test.html";
            var extentHtml = new ExtentHtmlReporter(reportpath);
            extentHtml.LoadConfig(projectPath + "extent-config.xml");
            extent = new ExtentReports();
            extent.AttachReporter(extentHtml);
            extent.AddSystemInfo("Host name", "Nalat");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User name", "Nalat");
        }

        [SetUp]
        public void Initialize()
        {
            //Select Browser here
            driver = Browsers.SelectBrowser("Chrome"); //Chrome,Firefox
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void SignInTest1()
        {

            String inputUsername = "TestUser";
            String inputPassword = "WrongPassword";

            HomePage homePage = new HomePage(driver, test);
            SignInPage signInPage = new SignInPage(driver,test); 
            ElementMethods elementMethods = new ElementMethods(driver, test);

            test.Log(Status.Info, "Step 1 : Navigate to WSECU website");
            homePage.NavigateToWSECU();

            test.Log(Status.Info, "Step 2 : Enter Username and click 'Sign in'");
            homePage.OnlineBankingSignIn("TestUser");

            test.Log(Status.Info, "Step 3 : Verify user navigate to Online Banking signin page");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='username']")));
            if (driver.Title.Equals("Sign in to Online Banking"))
            {
                test.Log(Status.Pass, "Navigate to Online Banking Sign In page successfully");
            }
            else
            {
                test.Log(Status.Fail, "Failed to navigate to Sign In page");
                Assert.Fail("Failed to navigate to Sign In page");
            }

            test.Log(Status.Info, "Step 4 : Verify Username entered in previous step populates on screen.");
            string username = signInPage.elmSingInUsername.GetAttribute("value");
            if (username.Equals(inputUsername))
            {
                test.Log(Status.Pass, "Username is populated");
            }
            else
            {
                test.Fail("Username is not populated");
            }

            test.Log(Status.Info, "Step 5 : Enter incorrect password and click 'Sign in'");
            signInPage.enterPassword(inputPassword);
            elementMethods.ClickSubmit(signInPage.btnSignIn);

            test.Log(Status.Info, "Step 6 : Verify error message display : 'Sorry, incorrect username.'");

            if (signInPage.txtErrorMessage.Displayed)
            {
                test.Log(Status.Pass, "Error message displays");
            }
            else
            {
                test.Log(Status.Fail, "Error message does not display");
            }
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Close();
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
        }

    }
}
