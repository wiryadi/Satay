using Infrastructure;
using Selenium;

namespace Specifications.Pages
{
    public class GoogleFinancePage : BasePage
    {

        public GoogleFinancePage(ICommandProcessor seleniumCommandProcessor) 
            : base(seleniumCommandProcessor)
        {
        }

        protected override string ExpectedUrl
        {
            get
            {
                return "http://www.google.com/finance";
            }
        }

        public string SignInLinkVisibility
        {
            get
            {
                const string locator = "css=.gaiabar > a";
                return GetVisibility(locator);
            }
        }

        public string GoogleAdVisibility
        {
            get
            {
                const string locator = "css=div#ad";
                return GetVisibility(locator);
            }
        }

        public string MarketSummaryVisibility
        {
            get
            {
                const string locator = "css=div#summary-news-story";
                return GetVisibility(locator);
            }
        }
    }
}