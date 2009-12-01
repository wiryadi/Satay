using NUnit.Framework;

namespace Infrastructure.Test
{
    public class SeleniumProviderTest
    {
        [Test]
        public void ShouldStartStopSeleniumServer()
        {
            SeleniumProvider.Startup();
            Assert.IsTrue(SeleniumProvider.PingSeleniumServer(), "Selenium server failed to start");
            SeleniumProvider.Shutdown();
            Assert.IsFalse(SeleniumProvider.PingSeleniumServer(), "Selenium server failed to shutdown");
        }
    }
}