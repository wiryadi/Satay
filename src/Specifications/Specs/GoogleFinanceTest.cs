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
        private DefaultSelenium selenium;
        public GoogleFinancePage GoogleFinancePage { get; set; }

        public void SetUp()
        {
            SeleniumProvider.Startup();
            selenium = SeleniumProvider.GetClient();
            GoogleFinancePage = new GoogleFinancePage(selenium.Processor);
        }


        public void TearDown()
        {
            if (selenium != null) selenium.Stop();
            SeleniumProvider.Shutdown();
        }
    }
}
