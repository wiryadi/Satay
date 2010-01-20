using Concordion.Integration;
using Infrastructure;

namespace Specifications.Specs
{
    [ConcordionTest]
    public class SearchTest : BaseWebFixture
    {
        public void EnterSearchKeyword(string keyword)
        {
            Browser.Focus("css=input#searchInput");
            Browser.Type("css=input#searchInput", keyword);
            Browser.ClickAndWaitForPageToLoad("css=input#searchGoButton");
        }

        public string PageCategory
        {
            get
            {
                if (Browser.IsVisible("css=table#toc"))
                {
                    return "Exact Match";
                }

                if (Browser.IsVisible("css=table#disambigbox"))
                {
                    return "Disambiguation";
                }

                return "Unknown";

            }

        }

        public string AutoCompleteResultsContain(string expectedResult)
        {
            return "contain";
        }
    }
}