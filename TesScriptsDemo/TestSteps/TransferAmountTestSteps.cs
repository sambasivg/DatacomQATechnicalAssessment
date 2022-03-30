using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesScriptsDemo.BaseDrivers;
using TesScriptsDemo.Pages;

namespace TesScriptsDemo.TestSteps
{
    public class TransferAmountTestSteps
    {
        [Obsolete]
        public AddNewPayeePage _addnewpayeepage;
        public BrowserDriver _browserDriver;
        public PayeePage _payeePage;
        public TransferAmountPage _transferAmountPage;

        [Obsolete]
        public TransferAmountTestSteps()
        {
            _payeePage = new PayeePage();
            _transferAmountPage = new TransferAmountPage();
            _browserDriver = new BrowserDriver();
        }

        [Obsolete]
        public void TransferAmountteststeps()
        {
            _payeePage.LaunchApplication();
            _payeePage.ClickOnMenu();
            _transferAmountPage.ClickOnPayOrTransfer();
            _transferAmountPage.TransferAmount("Everyday","Bills","500");

        }

        public void BrowserDispose()
        {
            _browserDriver.Dispose();
        }
    }
}
