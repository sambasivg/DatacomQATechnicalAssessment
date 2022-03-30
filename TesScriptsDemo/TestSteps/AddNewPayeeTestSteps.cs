using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesScriptsDemo.BaseDrivers;
using TesScriptsDemo.Pages;

namespace TesScriptsDemo.TestSteps
{
    public class AddNewPayeeTestSteps
    {

        [Obsolete]
        public AddNewPayeePage _addnewpayeepage;
        public BrowserDriver _browserDriver;

        [Obsolete]
        public AddNewPayeeTestSteps()
        {
            _addnewpayeepage = new AddNewPayeePage();
            _browserDriver = new BrowserDriver();
        }

        [Obsolete]
        public void AddNewPayeeSteps(Hashtable Addpyeedata)
        {
            
            NavigatetoPayeesTestSteps.CreateNavigatetoPayeesTestStepsObj().NavigatetoPayeesSteps();

            _addnewpayeepage.ClickOnAddButton();
            _addnewpayeepage.EnterPayeeName(Convert.ToString(Addpyeedata["PAYEENAME"]));
            _addnewpayeepage.EnterBankAccountNumber(Addpyeedata);
            _addnewpayeepage.ClickAddNewPayeeBtn();
            _addnewpayeepage.VerifyPayeeSuccessFullyAddedMessage(Convert.ToString(Addpyeedata["PAYEENAME"]));
           
            
        }

        [Obsolete]
        public void NavigatetoPayeeDetailsPage()
        {

            NavigatetoPayeesTestSteps.CreateNavigatetoPayeesTestStepsObj().NavigatetoPayeesSteps();
            _addnewpayeepage.ClickOnAddButton();
        }

        [Obsolete]
        public void EnterBlankPayeeNameAndClickAddSteps(String PayeeNmae)
        {

            _addnewpayeepage.EnterPayeeName(PayeeNmae);
            _addnewpayeepage.ClickAddNewPayeeBtn();
           
        }

        [Obsolete]
        public void EnterAllMandatoryFieldsSteps(String PayeeNmae,Hashtable ht)
        {

            _addnewpayeepage.EnterPayeeName(PayeeNmae);

            _addnewpayeepage.EnterBankAccountNumber(ht);
        }

        [Obsolete]
        public void ValidateErrorMessage(string expecmsg)
        {
            _addnewpayeepage.VerifyErrorMessage(expecmsg);
        }
        public void BrowserDispose()
        {
            _browserDriver.Dispose();
        }
    }
}
