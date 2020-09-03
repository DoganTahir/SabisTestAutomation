using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SabisTest.Page;
using SabisTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabisTest.Test
{
    [TestClass()]
    public class SabisLoginTest : AutomationBaseTest
    {
        private static TestContext testContext;
        private string message;
        private string stackMessage;
        [CacheLookup] private const string ERROR_LABEL_XPATH = "/html/body/div[1]/div[1]/strong";


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

        [TestMethod]
        public void TestScenario1()
        {
            try
            {
                SabisLoginPage sabisLoginPage = SabisLoginPage.Load(browser);
                sabisLoginPage.SendUsername(configuration.UserName);
                sabisLoginPage.SendPassword(configuration.Password);
                sabisLoginPage.ClickLoginButton();
                Assert.IsTrue(sabisLoginPage.IsLoginSuccessed("TAHİRDOĞAN"), "Giriş Yapılamadı");

            }
            catch (Exception e)
            {
                message = e.Message;
                stackMessage = e.StackTrace;
                throw;
            }
        }
        [TestMethod]
        public void TestScenario2()
        {

            try
            {
                SabisLoginPage sabisLoginPage = SabisLoginPage.Load(browser);
                sabisLoginPage.SendUsername("Test");
                sabisLoginPage.SendPassword(configuration.Password);
                sabisLoginPage.ClickLoginButton();
                Assert.AreEqual(browser.FindElement(By.XPath(ERROR_LABEL_XPATH)).Text, "Hata!");
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
