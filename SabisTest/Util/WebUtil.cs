using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SabisTest.Util
{
    public class WebUtil
    {
        public static WebUtil _webDriverFactory;
        public static Configuration configuration { get; private set; }
        private IWebDriver WebDriver;
        private Browser browser;

        public WebUtil()
        {

        }

        public static WebUtil GetInitial()
        {
            if (_webDriverFactory ==null)
            {
                _webDriverFactory = new WebUtil();
                try
                {
                    webDriverFactory.
                }
            }
        }

        Pub

        public IWebDriver CreateBrowser()
        {
            switch (Configuration.)}
            
    }
}
