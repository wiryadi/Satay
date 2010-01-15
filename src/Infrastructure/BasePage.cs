using System;

namespace Infrastructure
{
    public abstract class BasePage
    {
        protected  IBrowser Browser { get; private set;}

        protected static bool IsStarted { get; set; }

        protected BasePage()
        {
            Browser = new SeleniumBrowser();
        }

        public void Open(string url)
        {
            Browser.OpenAndWaitForPageToLoad(url);
        }

    }
}