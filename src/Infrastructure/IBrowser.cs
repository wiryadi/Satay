namespace Infrastructure
{
    public interface  IBrowser
    {
        void Open(string url);

        void WaitForPageToLoad();
        void WaitForPageToLoad(int milliseconds);

        void OpenAndWaitForPageToLoad(string url);
        void OpenAndWaitForPageToLoad(string url, int milliseconds);
        void Click(string locator);
        bool IsElementPresent(string locator);
        bool IsVisible(string locator);

        string GetLocation();
    }
}