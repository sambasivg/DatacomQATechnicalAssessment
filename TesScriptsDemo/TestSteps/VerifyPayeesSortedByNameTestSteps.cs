using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesScriptsDemo.BaseDrivers;
using TesScriptsDemo.Pages;

namespace TesScriptsDemo.TestSteps
{
    public class VerifyPayeesSortedByNameTestSteps
    {

        [Obsolete]
        public PayeePage _payeePage;
        public BrowserDriver _browserDriver;
        [Obsolete]
        public NavigatetoPayeesTestSteps _navigateToPayeesTestSteps;

        [Obsolete]
        public VerifyPayeesSortedByNameTestSteps()
        {
            _payeePage = new PayeePage();
            _browserDriver = new BrowserDriver();
           _navigateToPayeesTestSteps = new NavigatetoPayeesTestSteps();
        }

        [Obsolete]
        public void VerifyPayeesNamesSorted()
        {
            _navigateToPayeesTestSteps.NavigatetoPayeesSteps();
            _payeePage.VerifyPayeeSortByName();
        }
        public void BrowserDispose()
        {
            _browserDriver.Dispose();

        }

    }
}
