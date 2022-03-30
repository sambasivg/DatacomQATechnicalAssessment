using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace TesScriptsDemo.BaseDrivers
{
   public class BrowserDriverFactory
    {

  
        private readonly IConfiguration _config;
        private string solution_dir = System.Environment.CurrentDirectory;
        public string driverPath;

        public IWebDriver GetForBrowser(string browserId)
        {
            string upperBrowserId = browserId.ToUpper();
            switch (upperBrowserId)
            {
                case "IE": return GetInternetExplorerDriver();
                case "CHROME": return GetChromeDriver(false);
                case "CHROME-HEADLESS": return GetChromeDriver(true);
                case "FIREFOX": return GetFirefoxDriver();
                case "EDGE": return GetEdgeDriver();
                case string browser: throw new NotSupportedException($"{browser} is not a supported browser");
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }
        private IWebDriver GetEdgeDriver()
        {

            //string fldpath = System.IO.Directory.GetCurrentDirectory();
            // string fldpat = System.IO.Directory.GetParent(fldpath).ToString();
            driverPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName +  "\\TesScriptsDemo\\bin\\Debug\\net48";

          //  fldpat =System.IO.Directory.GetParent(fldpath).Root.ToString();
          
            //solution_dir = fldpat + "\\Users\\sneha\\source\\repos\\TesScriptsDemo\\TesScriptsDemo\\bin\\Debug\\net48";
           
            var _edgedriverService = EdgeDriverService.CreateDefaultService(driverPath);

            var EdgeOptions = new EdgeOptions();

            var _edgedriver = new EdgeDriver(_edgedriverService, EdgeOptions)
            {
                Url = ConfigurationManager.AppSettings["BNZDEMOURL"]
            };
        

            return _edgedriver;

        }

        private IWebDriver GetFirefoxDriver()
        {
            var firefoxDriverService = FirefoxDriverService.CreateDefaultService(driverPath);
            return new FirefoxDriver(firefoxDriverService)
            {
                Url = _config.GetConnectionString("BaseUrl")
            };
        }

        private IWebDriver GetChromeDriver(bool isHeadless)
        {
         
            var chromeDriverService = ChromeDriverService.CreateDefaultService(driverPath);

            var chromeOptions = new ChromeOptions();

            if (isHeadless)
            {
                chromeOptions.AddArgument("headless");
            }

            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions)
            {
                Url = _config.GetConnectionString("BaseUrl")
            };

            return chromeDriver;
        }

        private IWebDriver GetInternetExplorerDriver()
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,
            };
            return new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(driverPath), internetExplorerOptions)
            {
                Url = _config.GetConnectionString("BaseUrl")
            };
        }
    }
}

