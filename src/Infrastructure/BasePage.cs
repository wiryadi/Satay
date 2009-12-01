using Selenium;

namespace Infrastructure
{
    public abstract class BasePage : DefaultSelenium
    {
        protected static bool IsStarted { get; set; }
        private const string timeout = Constants.SeleniumTimeOut;
        protected virtual string ExpectedUrl
        {
            get { return ""; }
        }

        protected BasePage(ICommandProcessor seleniumCommandProcessor)
            : base(seleniumCommandProcessor)
        {
        }

        public void OpenAndWait()
        {
            Open(ExpectedUrl);
            WaitForPageToLoad(timeout);
        }

        public void ClickAndWait(string locator)
        {
            Click(locator);
            WaitForPageToLoad(timeout);
        }

        public virtual bool ActualUrlIsValid()
        {
            string actualUrl = GetLocation();
            return ExpectedUrl == actualUrl;
        }

        public string GetVisibility(string locator)
        {
            return (IsElementPresent(locator) && IsVisible(locator)) 
                ? "visible" 
                : "invisible";
        }
    }
}