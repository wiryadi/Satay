using System.Collections.Generic;
using Concordion.Integration;
using Infrastructure;

namespace Specifications.Specs
{
    [ConcordionTest]
    public class WikipediaHomeTest:BasePage
    {
        public const string HomePageUrl = "http://en.wikipedia.org/";

        private readonly Dictionary<string, string> elementMapping =
            new Dictionary<string, string>
            { 
                {"Logo", "css=div#p-logo"},
                {"SearchBox","css=input#searchInput" },
                {"LoginLink","css=li#pt-login"},
                {"FeaturedArticle", "css=div#mp-tfa"}
            };
                                                                    

        public void Open()
        {
            Open(HomePageUrl);
        }

        public string GetVisibility(string element)
        {
            bool visible = Browser.IsVisible(elementMapping[element]);
            return (visible) ? "visible" : "invisible";
        }

    }
}