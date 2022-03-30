using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TesScriptsDemo.BaseDrivers;

namespace TesScriptsDemo.Pages
{
    public class BasePage
    {
        public IWebDriver Driver { get; }
        public BrowserDriver _browserdriver;
        public BrowserDriverFactory _browserDriverFactory;

        [Obsolete]
        public BasePage()
            {

                _browserdriver = new BrowserDriver(_browserDriverFactory);


        }

        public void LaunchApplication()
        {
            _browserdriver.LaunchApplication();
           IWebDriver Driver = BrowserDriver._currentWebDriverLazy.Value;
            Driver.Manage().Window.Maximize();
        }
        public void MoveToCurrentWindow()
        {
            List<string> BrowsersList = _browserdriver.Current.WindowHandles.ToList();

            // Traverse each and every window 
            foreach (var handle in BrowsersList)
            {
                //Switch to Browser
                _browserdriver.Current.SwitchTo().Window(handle);
                Console.WriteLine("Switching to window - > " + handle.ToString());
            }
        }
      
    }
}
