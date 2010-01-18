using System;
using System.Collections.Generic;
using Concordion.Integration;
using Infrastructure;

namespace Specifications.Specs
{
    [ConcordionTest]
    public class WikipediaHomeTest : BaseWebFixture
    {
        public string GetVisibility(string element)
        {
            return Browser.IsVisible(MapElementToLocator(element))
                ? "visible"
                : "invisible";
        }

        public void ViewSource()
        {
            Browser.ClickAndWaitForPageToLoad(MapElementToLocator(Elements.ViewSourceTab));
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

        private string MapElementToLocator(Elements element)
        {
            return new Dictionary<Elements, string>
                       {
                           {Elements.Logo, "css=div#p-logo"},
                           {Elements.SearchBox, "css=input#searchInput"},
                           {Elements.LoginLink, "css=li#pt-login"},
                           {Elements.FeaturedArticle, "css=div#mp-tfa"},
                           {Elements.ViewSourceTab, "css=li#ca-viewsource>a"},
                           {Elements.ProtectedWarning, "css=table#mw-cascadeprotectedtext"}
                       }[element];
        }
 

        private string MapElementToLocator(string element)
        {
            return MapElementToLocator((Elements)Enum.Parse(typeof(Elements), element));
        }

        private bool ProtectedWarningIsDisplayed()
        {
            return Browser.IsVisible(MapElementToLocator(Elements.ProtectedWarning));
        }

    }
}