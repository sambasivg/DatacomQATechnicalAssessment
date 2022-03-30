using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesScriptsDemo.BaseDrivers;
using TesScriptsDemo.Pages;

namespace TesScriptsDemo.TestSteps
{
    public class NavigatetoPayeesTestSteps
    {
        [Obsolete]
        public PayeePage _payeePage;
        public BrowserDriver _browserDriver;

        [Obsolete]
        public NavigatetoPayeesTestSteps()
        {
            _payeePage = new PayeePage();
            _browserDriver = new BrowserDriver();
        }

        [Obsolete]
        public static NavigatetoPayeesTestSteps CreateNavigatetoPayeesTestStepsObj()
        {
            NavigatetoPayeesTestSteps navigatetopayeesTestSteps = new NavigatetoPayeesTestSteps();
            return navigatetopayeesTestSteps;
        }

        [Obsolete]
        public void NavigatetoPayeesSteps()
        {
            _payeePage.LaunchApplication();
            _payeePage.ClickOnMenu();
            _payeePage.ClickOnPayeeLink();
        }

        public void BrowserDispose()
        {
            _browserDriver.Dispose();

        }
    }
}
