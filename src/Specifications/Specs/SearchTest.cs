using System.Collections.Generic;
using Concordion.Integration;
using Infrastructure;

namespace Specifications.Specs
{
    [ConcordionTest]
    public class SearchTest : BaseWebFixture
    {
        public void EnterSearchKeyword(string keyword)
        {
            Browser.Focus(locatorMap[Elements.SearchInput]);
            Browser.Type(locatorMap[Elements.SearchInput], keyword);
            Browser.ClickAndWaitForPageToLoad(locatorMap[Elements.SearchButton]);
        }

        public string PageCategory
        {
            get
            {
                if (Browser.IsVisible(locatorMap[Elements.TableOfContent]))
                {
                    return "Exact Match";
                }

                if (Browser.IsVisible(locatorMap[Elements.DisambiguationWarningBox]))
                {
                    return "Disambiguation";
                }

                return "Unknown";

            }

        }

        private enum Elements
        {
            SearchInput,
            SearchButton,
            TableOfContent,
            DisambiguationWarningBox
        } ;

        private readonly Dictionary<Elements, string> locatorMap = new Dictionary<Elements, string>
        {
            {Elements.SearchInput, "css=input#searchInput" },
            {Elements.SearchButton, "css=input#searchGoButton"},
            {Elements.TableOfContent, "css=table#toc"},
            {Elements.DisambiguationWarningBox, "css=table#disambigbox"}                    
        };

    }
}