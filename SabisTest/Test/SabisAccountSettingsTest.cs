using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SabisTest.Page;
using SabisTest.Util;
using System;
namespace SabisTest.Test
{
    [TestClass()]
    public class SabisAccountSettingsTest : AutomationBaseTest
    {
        private static TestContext testContext;
        private string message;
        private string stackMessage;
        [CacheLookup] private const string SECONDARY_EMAIL_INPUT_ID = "ikincilEPosta";
        SabisLoginPage sabisLoginPage = SabisLoginPage.Load(browser);


        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            testContext = context;
            Initialize(BrowserType.CHROME, configuration.BaseUrl);
        }

        [TestCleanup]
        public void Cleanup()
        {
            GetResult(testContext, this.GetType().Name, message, stackMessage);
            message = "";
            stackMessage = "";
            browser.Manage().Cookies.DeleteAllCookies();
            browser.RefreshPage();
        }

        // Sabiste Kayıtlı Mail Adresi Kontrolü
        [TestMethod]
        public void TestScenario1()
        {
            

            try
            {
                browser.Url = "https://sabis.sakarya.edu.tr/tr/Login";
                SabisMainPage sabisMainPage = SabisMainPage.Load(browser);
                sabisLoginPage.SendUsername(configuration.UserName);
                sabisLoginPage.SendPassword(configuration.Password);
                sabisLoginPage.ClickLoginButton();
                sabisMainPage.ClickAccountMenu();
                sabisLoginPage.SendPassword(configuration.Password);
                sabisLoginPage.ClickLoginButton();
                SabisAccountSettingsPage sabisAccountSettingsPage = SabisAccountSettingsPage.Load(browser);
                sabisAccountSettingsPage.SecondaryEmailLabelClick();
                var email = browser.FindElement(By.Id(SECONDARY_EMAIL_INPUT_ID)).GetAttribute("value");
                Assert.AreEqual(email, "by_tahir@windowslive.com");
            }
            catch (Exception e)
            {
                message = e.Message;
                stackMessage = e.StackTrace;
                throw;
            }
        }

        [ClassCleanup]
        public static void FinishTest()
        {
            browser.Close();
            browser = new Browser();
            configuration = new Configuration();
        }

    }
}
