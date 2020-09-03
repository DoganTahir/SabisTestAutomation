using OpenQA.Selenium;
using SabisTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SabisTest.Page
{
    public abstract class AutomationBasePage
    {
        protected Browser browser;
        protected bool _result = true;
        protected Configuration configuration;
        protected const int DEFAULT_TIMEOUT = 30;

        private AutomationBasePage() { }
        protected AutomationBasePage(Browser browser)
        {
            this.browser = browser;
            _result = true;
            configuration = new Configuration();
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                browser.FindElement(by);
            }
            catch(Exception)
            {
                _result = false;
            }
            return _result;
        }
    }
}
