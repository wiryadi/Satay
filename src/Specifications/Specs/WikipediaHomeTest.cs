using System;
using System.Collections.Generic;
using Concordion.Integration;
using Infrastructure;

namespace Specifications.Specs
{
    [ConcordionTest]
    public class WikipediaHomeTest : BaseWebFixture
    {
        public string GetVisibility(string elementFromSpec)
        {
            var element= (Elements)Enum.Parse(typeof (Elements), elementFromSpec) ;
            return Browser.IsVisible(locatorMap[element])
                ? "visible"
                : "invisible";
        }

        public void ViewSource()
        {
            Browser.ClickAndWaitForPageToLoad(locatorMap[Elements.ViewSourceTab]);
        }

        public string GetPageMode()
        {
            return ProtectedWarningIsDisplayed()
                       ? "readonly"
                       : "readwrite";
        }

        private enum Elements
        {
            Logo,
            SearchBox,
            LoginLink,
            FeaturedArticle,
            ViewSourceTab,
            ProtectedWarning
        }

        private readonly Dictionary<Elements, string> locatorMap = new Dictionary<Elements, string>
        {
                           {Elements.Logo, "css=div#p-logo"},
                           {Elements.SearchBox, "css=input#searchInput"},
                           {Elements.LoginLink, "css=li#pt-login"},
                           {Elements.FeaturedArticle, "css=div#mp-tfa"},
                           {Elements.ViewSourceTab, "css=li#ca-viewsource>a"},
                           {Elements.ProtectedWarning, "css=table#mw-cascadeprotectedtext"}
        };
 
        private bool ProtectedWarningIsDisplayed()
        {
            return Browser.IsVisible(locatorMap[Elements.ProtectedWarning]);
        }

    }
}