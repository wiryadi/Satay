using Selenium;

namespace Infrastructure
{
    public class SeleniumBrowser : IBrowser
    {
        private static readonly ISelenium selenium;

        static SeleniumBrowser()
        {
            SeleniumProvider.Startup();
            selenium = SeleniumProvider.GetClient();
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

        public void OpenAndWaitForPageToLoad(string url, int milliseconds)
        {
            selenium.Open(url);
            selenium.WaitForPageToLoad(milliseconds.ToString());
        }

        public void Click(string locator)
        {
            selenium.Click(locator);
        }

        public bool IsElementPresent(string locator)
        {
            return selenium.IsElementPresent(locator);
        }

        public bool IsVisible(string locator)
        {
            return selenium.IsElementPresent(locator) && selenium.IsVisible(locator);
        }

        public string GetLocation()
        {
            return selenium.GetLocation();
        }
    }
}