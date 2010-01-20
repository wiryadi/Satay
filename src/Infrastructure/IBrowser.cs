namespace Infrastructure
{
    public interface  IBrowser
    {
        void StartSession();
        void StopSession();

        void Open(string url);

        void WaitForPageToLoad();
        void WaitForPageToLoad(int timeoutMilliseconds);

        void OpenAndWaitForPageToLoad(string url);
        void OpenAndWaitForPageToLoad(string url, int timeoutMilliseconds);

        void Click(string locator);
        void ClickAndWaitForPageToLoad(string locator);
        void ClickAndWaitForPageToLoad(string locator, int timeoutMilliseconds);
        
        bool IsElementPresent(string locator);
        bool IsVisible(string locator);

        void Type(string locator, string value);
        void TypeKeys(string locator, string value);

        void Focus(string locator);

        string GetText(string locator);

        bool WaitForElementToBeVisible(string locator);
        bool WaitForElementToBeVisible(string locator, int timeout);

        string GetLocation();
    }
}