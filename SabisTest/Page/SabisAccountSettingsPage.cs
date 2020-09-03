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
    public class SabisAccountSettingsPage : AutomationBasePage
    {
        [CacheLookup] private const string SECONDARY_EMAIL_LABEL_XPATH = "/html/body/div[2]/div[1]/div/div[2]/div/div[1]/h4/ul/li[3]/a";
        [CacheLookup] private const string UPDATE_EMAIL_BUTTON = "/html/body/div[2]/div[1]/div/div[2]/div/div[2]/div/div[2]/div/form/div[2]/div[2]/a";

        protected SabisAccountSettingsPage(Browser browser) : base(browser)
        {


        }
        public static SabisAccountSettingsPage Load(Browser browser)
        {
            return new SabisAccountSettingsPage(browser);
        }
        public void SecondaryEmailLabelClick()
        {
            browser.FindElement(By.XPath(SECONDARY_EMAIL_LABEL_XPATH)).Click();
            browser.WaitForSecond();
        }

    }
}
