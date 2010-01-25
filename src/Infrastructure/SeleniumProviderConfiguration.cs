namespace Infrastructure
{
    public class SeleniumProviderConfiguration
    {
        private readonly string jvmOptions;
        private readonly string seleniumJar;
        private readonly string targetedBrowser;
        private readonly int seleniumServerPort;

        private const string seleniumOptionsForNonIeBrowsers = @"-singleWindow";


        public SeleniumProviderConfiguration(string seleniumJar, string targetedBrowser, int seleniumServerPort)
        {
            jvmOptions = "-Xms128M -Xmx512M";
            this.seleniumJar = seleniumJar;
            this.targetedBrowser = targetedBrowser;
            this.seleniumServerPort = seleniumServerPort;
        }

        public string GetArguments()
        {
            return string.Format(@" {0} -jar {1} {2} -port {3}",
                                 jvmOptions,
                                 seleniumJar,
                                 targetedBrowser != "*iexplore" ? seleniumOptionsForNonIeBrowsers : @"",
                                 seleniumServerPort);
        }
    }
}