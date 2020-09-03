using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
                    _webDriverFactory.CreateBrowser();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }
            return _webDriverFactory;

        }

        public IWebDriver CreateBrowser()
        {
            switch (configuration.Type)
            {
                case "chrome":
                    InitializeChromeDriver();
                    break;
            }
            browser = new Browser();
            return browser;
        }
        public static Browser GetBrowser(Configuration config)
        {
            configuration = config;
            return GetInitial().browser;
        }

        public void InitializeChromeDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-extension");
            chromeOptions.AddArgument("--start-maximized");
            WebDriver = new ChromeDriver(chromeOptions);
            WebDriver.Url = configuration.BaseUrl;
        }

        public IWebDriver GetWebDriver()
        {
            return WebDriver;
        }           
    }
}
