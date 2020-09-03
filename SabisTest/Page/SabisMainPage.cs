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
    public class SabisMainPage : AutomationBasePage
    {
        [CacheLookup] private const string MYACCOUNT_ICON_XPATH = "/html/body/div[2]/div[1]/div/div[2]/div[13]/a/div[1]/div/i";
        [CacheLookup] private const string FOODMENU_ICON_XPATH = "/html/body/div[2]/div[1]/div/div[2]/div[11]/a/div[1]/div/i";
        [CacheLookup] private const string OBS_ICON_XPATH = "/html/body/div[2]/div[1]/div/div[2]/div[2]/a/div[2]";
        [CacheLookup] private const string EMAILBOX_ICON_XPATH = "/html/body/div[2]/div[1]/div/div[2]/div[1]/a/div[2]";

        protected SabisMainPage(Browser browser) : base(browser)
        {

        }
        public static SabisMainPage Load(Browser browser)
        {
            return new SabisMainPage(browser);
        }
        public  void ClickFoodMenu()
        {
            browser.FindElement(By.XPath(FOODMENU_ICON_XPATH)).Click();
            browser.WaitForSecond();
        }
        public void ClickEmailMenu()
        {
            browser.FindElement(By.XPath(EMAILBOX_ICON_XPATH)).Click();
            browser.WaitForSecond();
        }
        public void ClickOBSMenu()
        {
            browser.FindElement(By.XPath(OBS_ICON_XPATH)).Click();
            browser.WaitForSecond();
        }
        public void ClickAccountMenu()
        {
            browser.FindElement(By.XPath(MYACCOUNT_ICON_XPATH)).Click();
            browser.WaitForSecond();
        }
    }
}
