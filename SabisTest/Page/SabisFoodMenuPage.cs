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
    public class SabisFoodMenuPage : AutomationBasePage
    {
        [CacheLookup] private const string DIET_BUTTON_XPATH = "/html/body/header/div/div[2]/div/div/div[3]/div/div/ul/li/a";
        [CacheLookup] private const string DINING_HALL_XPATH = "/html/body/header/div/div[2]/div/div/div[2]/div/nav/ul/li[4]/a";

      
        protected SabisFoodMenuPage(Browser browser) : base(browser)
        {

        }
        public static SabisFoodMenuPage Load(Browser browser)
        {
            return new SabisFoodMenuPage(browser);
        }
        public void DietButtonClick()
        {
            browser.FindElement(By.XPath(DIET_BUTTON_XPATH)).Click();
            browser.WaitForSecond();
        }

        public void DiningHallLabelClick()
        {
            browser.FindElement(By.XPath(DINING_HALL_XPATH)).Click();
            browser.WaitForSecond();
        }
    }
}
