using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using Selenium;

namespace Infrastructure
{
    /// <summary>
    /// To change browser type, set SELENIUM_BROWSER environment variable to the target browser type
    /// e.g.: SET SELENIUM_BROWSER=*iexplore
    /// </summary>
    public class SeleniumProvider
    {
        private const string javaExe = "java.exe";
        private const string seleniumServerHost = Constants.SeleniumServerHost;
        private const int seleniumServerPort = Constants.SeleniumServerPort;

        private static int referenceCount;
        private static Process seleniumServer;

        static SeleniumProvider()
        {
            Startup();
            ShutdownSeleniumOnProcessExit();
        }

        public static void Startup()
        {
            if (referenceCount == 0)
            {
                StartupServer();
            }
            referenceCount++;
        }

        public static void Shutdown()
        {
 
            referenceCount--;
            if (referenceCount != 0)
            {
                return;
            }
            CloseSeleniumServerAndWait();
        }

        public static DefaultSelenium GetClient()
        {
            return GetClient(Constants.RootUrl);
        }

        public static DefaultSelenium GetClient(string url)
        {
            var selenium = new DefaultSelenium(seleniumServerHost, seleniumServerPort, GetTargetedBrowser(), url);
            selenium.Start();
            return selenium;
        }

        private static string GetBaseDirectory()
        {
            string currentAssemblyFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var currentDir = new DirectoryInfo(currentAssemblyFullPath);
            var parentDir = currentDir.Parent;
            
            if (parentDir == null) return "c:\\";
            var grandParentDir = parentDir.Parent;
            
            if (grandParentDir == null) return "c:\\";

            return grandParentDir.FullName;
        }

        private static void StartupServer()
        {
            var seleniumPath = Path.Combine(GetBaseDirectory(), "tools");
            seleniumPath = Path.Combine(seleniumPath, "selenium-server");
            seleniumPath = Path.Combine(seleniumPath, "selenium-server.jar");

            var seleniumProviderConfiguration = new SeleniumProviderConfiguration(seleniumPath, GetTargetedBrowser(), seleniumServerPort);

            seleniumServer = new Process
                                 {
                                     StartInfo =
                                         {
                                             FileName = javaExe,
                                             Arguments = seleniumProviderConfiguration.GetArguments()
                                         }
                                 };
            seleniumServer.Start();
            WaitUntilTheServerHasStarted();
        }

        public static string GetTargetedBrowser()
        {
            return Environment.GetEnvironmentVariable("SELENIUM_BROWSER") ?? "*firefox";
        }

        public static bool PingSeleniumServer()
        {
            var myWebClient = new WebClient();
            var seleniumServerUrl = string.Format("http://{0}:{1}/selenium-server/core/", seleniumServerHost, seleniumServerPort);
            try
            {
                using (Stream myStream = myWebClient.OpenRead(seleniumServerUrl))
                {
                    var sr = new StreamReader(myStream);
                    Console.WriteLine(sr.ReadToEnd());
                }

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }

        private static void CloseSeleniumServerAndWait()
        {
            if (seleniumServer != null)
            {
                seleniumServer.Kill();
            }
        }

        private static void ShutdownSeleniumOnProcessExit()
        {
            AppDomain.CurrentDomain.DomainUnload += ((sender, e) => Shutdown());
        }

        private static void WaitUntilTheServerHasStarted()
        {
            var count = 0;
            const int timeout = 60;
            while (count < timeout)
            {
                try
                {
                    bool seleniumServerIsActive = PingSeleniumServer();

                    if (seleniumServerIsActive) break;
                }
                catch (WebException)
                {
                    count++;
                    Thread.Sleep(1000);
                }
            }
        }

    }
}