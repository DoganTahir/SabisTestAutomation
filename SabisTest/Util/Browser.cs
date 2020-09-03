using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SabisTest.Util
{
    public class Browser : IWebDriver
    {
        public int DEFAULT_TIMEOUT { get; set; }

        public Browser()
        {
            DEFAULT_TIMEOUT = 30;
        }

        public IWebDriver GetWebDriver()
        {
            return WebUtil.GetInitial().GetWebDriver();
        }


        public string CurrentWindowHandle
        {
            get
            {
                return GetWebDriver().CurrentWindowHandle;
            }
        }

        public string PageSource
        {
            get
            {
                return GetWebDriver().PageSource;
            }
        }

        public string Title
        {
            get
            {
                return GetWebDriver().Title;
            }
        }

        public string Url
        {
            get
            {
                return GetWebDriver().Url;

            }
            set
            {
                GetWebDriver().Url = value;
            }
        }

        public ReadOnlyCollection<string> WindowHandles
        {
            get { return GetWebDriver().WindowHandles; }
        }

        public void Dispose()
        {
            GetWebDriver().Dispose();
        }

        public void Close()
        {
            GetWebDriver().Close();
        }

        public IWebElement FindElement(By by)
        {
            return FindWebElementWhileWaitingFluently(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return GetWebDriver().FindElements(by);
        }

        public IOptions Manage()
        {
            return GetWebDriver().Manage();
        }

        public INavigation Navigate()
        {
            return GetWebDriver().Navigate();
        }

        public void Quit()
        {
            GetWebDriver().Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return GetWebDriver().SwitchTo();
        }

        public void WaitForElementExists(int seconds, By elementLocator)
        {
            (new WebDriverWait(this, TimeSpan.FromSeconds(seconds))).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
        }

        public void WaitForClickable(int seconds, By elementLocator)
        {
            (new WebDriverWait(this, TimeSpan.FromSeconds(seconds))).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
        }

        public void WaitForElementVisible(int seconds, By elementLocator)
        {
            (new WebDriverWait(this, TimeSpan.FromSeconds(seconds))).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
        }

        public void WaitForAlertIsPresent(int seconds)
        {
            (new WebDriverWait(this, TimeSpan.FromSeconds(seconds))).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public void SendKeysForId(string id, string text)
        {
            FindElement(By.Id(id)).Clear();
            FindElement(By.Id(id)).SendKeys(text);
        }

        public void SendKeysForXpath(string xpath, string text)
        {
            FindElement(By.XPath(xpath)).Clear();
            FindElement(By.XPath(xpath)).SendKeys(text);
        }

        public void SendKeysForName(string name, string text)
        {
            FindElement(By.Name(name)).Clear();
            FindElement(By.Name(name)).SendKeys(text);
        }

        public void SendKeysForClassName(string className, string text)
        {
            FindElement(By.ClassName(className)).Clear();
            FindElement(By.ClassName(className)).SendKeys(text);
        }

        public void SendKeysForCssSelector(string cssSelector, string text)
        {
            FindElement(By.CssSelector(cssSelector)).Clear();
            FindElement(By.CssSelector(cssSelector)).SendKeys(text);
        }

        public void SelectOptionText(IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        public void SelectOptionValue(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public void SelectOptionIndex(IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public void CheckRadioButtonById(String id)
        {
            FindElement(By.Id(id)).Click();
        }

        public void CheckRadioButtonByXpath(String xpath)
        {
            FindElement(By.XPath(xpath)).Click();
        }

        public void CheckRadioButtonByName(String name)
        {
            FindElement(By.Name(name)).Click();
        }

        public void CheckRadioButtonByClassName(String className)
        {
            FindElement(By.ClassName(className)).Click();
        }

        public void CheckRadioButtonByCssSelector(String cssSelector)
        {
            FindElement(By.CssSelector(cssSelector)).Click();
        }

        public void ClickById(String id)
        {
            FindElement(By.Id(id)).Click();
        }

        public void ClickByXpath(String xpath)
        {
            FindElement(By.XPath(xpath)).Click();
        }

        public void ClickByName(String name)
        {
            FindElement(By.Name(name)).Click();
        }

        public void ClickByClassName(String className)
        {
            FindElement(By.ClassName(className)).Click();
        }

        public void ClickByCssSelector(String cssSelector)
        {
            FindElement(By.CssSelector(cssSelector)).Click();
        }


        public string GetTextById(string id)
        {
            return FindElement(By.Id(id)).Text;
        }

        public string GetTextByXpath(string xpath)
        {
            return FindElement(By.XPath(xpath)).Text;
        }

        public string GetTextByName(string name)
        {
            return FindElement(By.Name(name)).Text;
        }

        public string GetTextByClassName(string className)
        {
            return FindElement(By.ClassName(className)).Text;
        }

        public string GetTextByCssSelector(string cssSelector)
        {
            return FindElement(By.CssSelector(cssSelector)).Text;
        }

        public string GetAttributeById(string id, string attribute)
        {
            return FindElement(By.Id(id)).GetAttribute(attribute);
        }

        public string GetAttributeByXpath(string xpath, string attribute)
        {
            return FindElement(By.XPath(xpath)).GetAttribute(attribute);
        }

        public string GetAttributeByName(string name, string attribute)
        {
            return FindElement(By.Name(name)).GetAttribute(attribute);
        }

        public string GetAttributeByClassName(string className, string attribute)
        {
            return FindElement(By.ClassName(className)).GetAttribute(attribute);
        }

        public string GetAttributeByCssSelector(string cssSelector, string attribute)
        {
            return FindElement(By.CssSelector(cssSelector)).GetAttribute(attribute);
        }

        public void RefreshPage()
        {
            GetWebDriver().Navigate().Refresh();
        }

        public void BackPage()
        {
            GetWebDriver().Navigate().Back();
        }

        public void ForwardPage()
        {
            GetWebDriver().Navigate().Forward();
        }

        public void SendKeyword(By by, string key)
        {
            FindElement(by).SendKeys(key);
        }

        public void ScrollBy(int x, int y)
        {
            ((IJavaScriptExecutor)GetWebDriver())
                .ExecuteScript("window.scrollBy(" + x + ", " + y + ");");
        }

        public void WaitForSecond()
        {
            Thread.Sleep(1000);
        }
        private IWebElement FindWebElementWhileWaitingFluently(By selector)
        {
            WebDriverWait wait = new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(DEFAULT_TIMEOUT));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(selector));
        }

    }

}
