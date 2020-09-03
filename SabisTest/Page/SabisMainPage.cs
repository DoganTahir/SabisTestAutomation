using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabisTest.Page
{
    public class SabisMainPage
    {
        [CacheLookup] private const string MYACCOUNT_ICON_XPATH = "/html/body/div[2]/div[1]/div/div[2]/div[13]/a/div[1]/div/i";
        [CacheLookup] private const string FOODMENU_ICON_XPATH = "/html/body/div[2]/div[1]/div/div[2]/div[11]/a/div[1]/div/i";

    }
}
