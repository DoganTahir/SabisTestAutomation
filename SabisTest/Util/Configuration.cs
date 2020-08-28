using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabisTest.Util
{
    public class Configuration
    {
        public string Type { get; set; }

        public Configuration()
        {
            var config = SabisTest.Properties.Settings1.Default;
            Type = BrowserType.CHROME;
        }
    }


}
