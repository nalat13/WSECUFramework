using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSECUFramework.Utilities;

namespace WSECUFramework.Pages
{
    class SignInPage
    {
        IWebDriver driver;
        ExtentTest test;
        ElementMethods elementMethods;

        [FindsBy(How = How.XPath, Using = "//input[@name='username']")]
        public IWebElement elmSingInUsername;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        public IWebElement elmSingInPassword;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement btnSignIn;

        [FindsBy(How = How.XPath, Using = "//div[text() ='Sorry, incorrect username.']")]
        public IWebElement txtErrorMessage;

        public SignInPage(IWebDriver driver, ExtentTest test)
        {
            this.driver = driver;
            this.test = test;
            PageFactory.InitElements(driver, this);
            elementMethods = new ElementMethods(driver, test);
        }

        public void enterPassword(string password)
        {
            elementMethods.EnterText(elmSingInPassword, password);
            //elmSingInPassword.SendKeys(password);
        }
    }
}
