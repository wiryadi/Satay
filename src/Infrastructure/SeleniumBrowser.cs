using System;
using Selenium;

namespace Infrastructure
{
    public class SeleniumBrowser : IBrowser
    {
        private ISelenium selenium;


        #region IBrowser Members

        public void StartSession()
        {
            selenium = SeleniumProvider.GetClient();
            selenium.Open(Constants.RootUrl);
        }

        public void StopSession()
        {
            selenium.Stop();
        }

        public void Open(string url)
        {
            selenium.Open(url);
        }

        public void WaitForPageToLoad()
        {
            WaitForPageToLoad(Constants.SeleniumTimeOut);
        }

        public void WaitForPageToLoad(int milliseconds)
        {
            selenium.WaitForPageToLoad(milliseconds.ToString());
        }

        public void OpenAndWaitForPageToLoad(string url)
        {
            OpenAndWaitForPageToLoad(url, Constants.SeleniumTimeOut);
        }

        public void OpenAndWaitForPageToLoad(string url, int timeoutMilliseconds)
        {
            selenium.Open(url);
            selenium.WaitForPageToLoad(timeoutMilliseconds.ToString());
        }

        public void Click(string locator)
        {
            selenium.Click(locator);
        }

        public void ClickAndWaitForPageToLoad(string locator)
        {
            ClickAndWaitForPageToLoad(locator, Constants.SeleniumTimeOut);
        }

        public void ClickAndWaitForPageToLoad(string locator, int timeoutMilliseconds)
        {
            selenium.Click(locator);
            selenium.WaitForPageToLoad(timeoutMilliseconds.ToString());
        }

        public bool IsElementPresent(string locator)
        {
            return selenium.IsElementPresent(locator);
        }

        public bool IsVisible(string locator)
        {
            return selenium.IsElementPresent(locator) && selenium.IsVisible(locator);
        }

        public void Type(string locator, string value)
        {
            selenium.Type(locator, value);
        }

        public void TypeKeys(string locator, string value)
        {
            selenium.TypeKeys(locator, value);
        }

        public void Focus(string locator)
        {
            selenium.Focus(locator);
        }

        public string GetText(string locator)
        {
            return selenium.GetText(locator);
        }

        public string GetLocation()
        {
            return selenium.GetLocation();
        }

        public bool WaitForElementToBeVisible(string domId)
        {
            return WaitForElementToBeVisible(domId, Constants.SeleniumTimeOut);
        }

        public bool WaitForElementToBeVisible(string domId, int timeout)
        {
            string script = string.Format("selenium.isVisible('{0}');", domId );
            try
            {
                selenium.WaitForCondition(script, timeout.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

    }
}