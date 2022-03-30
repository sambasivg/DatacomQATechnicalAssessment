using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace TesScriptsDemo.BaseDrivers
{

    public class BrowserDriver : IDisposable
        {
            private readonly BrowserDriverFactory _browserSeleniumDriverFactory;
            public  IConfiguration _config;
          
            public static  Lazy<IWebDriver> _currentWebDriverLazy;
            private  Lazy<WebDriverWait> _waitLazy;
            private  TimeSpan _waitDuration = TimeSpan.FromSeconds(20);
            private bool _isDisposed;
            private  Actions _actions;
        public BrowserDriver()
        {

        }
            public BrowserDriver(BrowserDriverFactory browserSeleniumDriverFactory)
            {
            _browserSeleniumDriverFactory = new BrowserDriverFactory();
               // _config = new ConfigurationManager();
                
            }

        public void LaunchApplication()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
             _waitLazy = new Lazy<WebDriverWait>(GetWebDriverWait);
            _actions = new Actions(Current);
            Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            GetWebDriverWait();
        }
            public IWebDriver Current => _currentWebDriverLazy.Value;

            public WebDriverWait Wait => _waitLazy.Value;

        [Obsolete]
        public void WaitUntilVisible(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(Current, TimeSpan.FromSeconds(20));
            //while (!(Current.FindElements(By.XPath(xpath)).Count > 0))
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        [Obsolete]
        public void WaitUntilClickable(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(Current, TimeSpan.FromSeconds(20));
            //while (!(Current.FindElements(By.XPath(xpath)).Count > 0))
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
        }

        [Obsolete]
        public void WaitUntilElementPresent(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(Current, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.UrlToBe("https://www.demo.bnz.co.nz/client/payees"));
        }
        [Obsolete]
        public void WaitUntilTextpresent(IWebElement webele,string value)
        {
            WebDriverWait wait = new WebDriverWait(Current, TimeSpan.FromSeconds(20));

            wait.Until((ExpectedConditions.TextToBePresentInElement(webele, value)));
        }
        public WebDriverWait GetWebDriverWait()
            {
                return new WebDriverWait(Current, _waitDuration);
            }

            public IWebDriver GetWebDriver()
            {
           


                return _browserSeleniumDriverFactory.GetForBrowser(ConfigurationManager.AppSettings["Browser"]);
            }


            public void Dispose()
            {
                if (_isDisposed)
                {
                    return;
                }

                if (_currentWebDriverLazy.IsValueCreated)
                {
                    Current.Quit();
                }

                _isDisposed = true;
            }

           
    }
}

