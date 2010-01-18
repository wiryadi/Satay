using System;

namespace Infrastructure
{
    public abstract class BaseWebFixture
    {
        protected  IBrowser Browser { get; private set;}

        protected abstract string MapElementToLocator(string element);

        protected abstract string MyUrl { get; }

        protected BaseWebFixture()
        {
            Browser = new SeleniumBrowser();
        }

        public virtual void Open()
        {
            Browser.OpenAndWaitForPageToLoad(MyUrl);
        }

        public string GetVisibility(string element)
        {
            return Browser.IsVisible(MapElementToLocator(element)) 
                ? "visible" 
                : "invisible";
        }

    }
}