using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SabisTest.Util
{
    public class Configuration
    {
        public string Type { get; set; }
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Configuration()
        {
            var config = SabisTest.Properties.Settings1.Default;
            Type = BrowserType.CHROME;
            this.BaseUrl = config.BaseUrl;
            this.UserName = config.UserName;
            this.Password = config.Password;
        }
    }


}
