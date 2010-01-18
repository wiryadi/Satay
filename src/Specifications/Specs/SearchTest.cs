using System;
using Concordion.Integration;
using Infrastructure;

namespace Specifications.Specs
{
    [ConcordionTest]
    public class SearchTest:BaseWebFixture
    {
        protected override string MapElementToLocator(string element)
        {
            throw new NotImplementedException();
        }

        protected override string MyUrl
        {
            get { throw new NotImplementedException(); }
        }
    }
}