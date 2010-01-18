using System.Collections.Generic;
using Concordion.Integration;
using Infrastructure;

namespace Specifications.Specs
{
    [ConcordionTest]
    public class WikipediaHomeTest:BaseWebFixture
    {
        protected override string MyUrl
        {
            get { return "http://en.wikipedia.org/"; }
        }

        protected override string MapElementToLocator(string element)
        {
            return new Dictionary<string, string>
                       { 
                           {"Logo", "css=div#p-logo"},
                           {"SearchBox","css=input#searchInput" },
                           {"LoginLink","css=li#pt-login"},
                           {"FeaturedArticle", "css=div#mp-tfa"}
                       }[element];
        }
    }
}