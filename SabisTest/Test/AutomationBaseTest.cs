using Microsoft.VisualStudio.TestTools.UnitTesting;
using SabisTest.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabisTest.Test
{
    public class AutomationBaseTest
    {
        protected static Browser browser;
        protected static Configuration configuration = new Configuration();
        protected static bool _alltests;

        protected static void Initialize(string browserType,string url)
        {
            configuration.Type = browserType;
            configuration.BaseUrl = url;
            browser = WebUtil.GetBrowser(configuration);
            _alltests = false;
        }

        protected static void Initialize(string browserType)
        {
            configuration.Type = browserType;
            browser = WebUtil.GetBrowser(configuration);
            _alltests = false;
        } 

        protected static void Initialize()
        {
            browser = WebUtil.GetBrowser(configuration);
            _alltests = false;
        }
        protected void GetResult(TestContext testContext,string className,string message,string stackMessage)
        {
            if(testContext.CurrentTestOutcome==UnitTestOutcome.Failed)
            {
                var msg = message;
                var stackTrace = stackMessage;
                var dateFormat = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, TimeZone.CurrentTimeZone.StandardName);
                var str = dateFormat.ToString("dd.MM.yy-HH.mm.ss", CultureInfo.CurrentCulture);
            }
        }
    }
}
