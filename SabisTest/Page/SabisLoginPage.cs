using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SabisTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabisTest.Page
{
    public class SabisLoginPage : AutomationBasePage
    {
        [CacheLookup] private const string USERNAME_INPUT_ID = "UserName";
        [CacheLookup] private const string PASSWORD_INPUT_ID = "Password";
        [CacheLookup] private const string LOGIN_BUTTON_ID = "btnLogin";
        [CacheLookup] private const string USERNAME_LABEL_XPATH = "/html/body/header/ul/li[1]/a/span";

        protected SabisLoginPage(Browser browser) : base(browser)
        {

        }
        public static SabisLoginPage Load(Browser browser)
        {
            return new SabisLoginPage(browser);
        }
        public void SendUsername(string text)
        {
            browser.SendKeysForId(USERNAME_INPUT_ID, text);
            browser.SendKeyword(By.Id(USERNAME_INPUT_ID), Keys.Tab);
        }
        public void SendPassword(string text)
        {
            browser.SendKeysForId(PASSWORD_INPUT_ID, text);
            browser.SendKeyword(By.Id(PASSWORD_INPUT_ID), Keys.Tab);
        }
        public void ClickLoginButton()
        {
            browser.FindElement(By.Id(LOGIN_BUTTON_ID)).Click();
            browser.WaitForSecond();
        }
        
        public bool IsLoginSuccessed(string text)
        {
            return browser.FindElement(By.XPath(USERNAME_LABEL_XPATH)).Text == text;
        }
    }
}
