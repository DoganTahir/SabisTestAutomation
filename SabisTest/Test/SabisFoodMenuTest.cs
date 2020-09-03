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
    [TestClass]
    public class SabisFoodMenuTest : AutomationBaseTest
    {
        private static TestContext testContext;
        private string message;
        private string stackMessage;
        SabisLoginPage sabisLoginPage = SabisLoginPage.Load(browser);
        SabisMainPage sabisMainPage = SabisMainPage.Load(browser);
        [CacheLookup] private const string DIET_LABEL_XPATH = "/html/body/header/div/div[2]/div/div/div[3]/div/div/ul/li/small/i";
        [CacheLookup] private const string DINING_HALL_LABEL_XPATH = "/html/body/div[1]/div/div/h1";
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

        //Diyet Menüsünün  Görüntülenmesi
        [TestMethod]
        public void TestScenario1()
        {

            try
            {
                browser.Url = "https://sabis.sakarya.edu.tr/tr/Login";
                sabisLoginPage.SendUsername(configuration.UserName);
                sabisLoginPage.SendPassword(configuration.Password);
                sabisLoginPage.ClickLoginButton();
                sabisMainPage.ClickFoodMenu();
                SabisFoodMenuPage sabisFoodMenuPage = SabisFoodMenuPage.Load(browser);
                sabisFoodMenuPage.DietButtonClick();
                Assert.AreEqual(browser.FindElement(By.XPath(DIET_LABEL_XPATH)).Text, "Diyet Menüdesiniz");
            }
            catch (Exception e)
            {
                message = e.Message;
                stackMessage = e.StackTrace;
                throw;
            }
        }

        //Yemekhaneler Sayfasının Yüklenmesi
        [TestMethod]
        public void TestScenario2()
        {

            try
            {
                browser.Url = "https://sabis.sakarya.edu.tr/tr/Login";
                sabisLoginPage.SendUsername(configuration.UserName);
                sabisLoginPage.SendPassword(configuration.Password);
                sabisLoginPage.ClickLoginButton();
                sabisMainPage.ClickFoodMenu();
                SabisFoodMenuPage sabisFoodMenuPage = SabisFoodMenuPage.Load(browser);
                sabisFoodMenuPage.DiningHallLabelClick();
                Assert.AreEqual(browser.FindElement(By.XPath(DINING_HALL_LABEL_XPATH)).Text, "YEMEKHANELER");
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
