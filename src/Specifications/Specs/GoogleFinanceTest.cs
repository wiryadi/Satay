using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concordion.Integration;
using Infrastructure;
using Selenium;
using Specifications.Pages;

namespace Specifications.Specs
{
    [ConcordionTest]
    public class GoogleFinanceTest
    {
        public GoogleFinancePage GoogleFinancePage { get; set; }

        public GoogleFinanceTest()
        {
            GoogleFinancePage = new GoogleFinancePage();
        }

    }
}
