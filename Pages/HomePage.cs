using AventStack.ExtentReports;
using NUnit.Framework;
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
    class HomePage
    {
        IWebDriver driver;
		ExtentTest test;
		ElementMethods elementMethods;

		[FindsBy(How = How.Id, Using = "digital-banking-username")]
		public IWebElement elmUsername;

		[FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
		public IWebElement btnOnlineBankingSignIn;

		public HomePage(IWebDriver driver, ExtentTest test)
		{
			this.driver = driver;
			this.test = test;
			PageFactory.InitElements(driver, this);
			elementMethods = new ElementMethods(driver,test);
		}

		public void NavigateToWSECU()
		{
			driver.Navigate().GoToUrl("https://wsecu.org/");
			Assert.AreEqual(driver.Title, "The Credit Union for Washington | WSECU");
		}

		public void OnlineBankingSignIn(string userName)
		{
			elementMethods.EnterText(elmUsername, userName);
			elementMethods.ClickSubmit(btnOnlineBankingSignIn);
		}

	}
}
