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

    public class VerifypayeenamErrorMessageTestSteps
    {
        [Obsolete]
        public AddNewPayeeTestSteps _addnewpayeeteststeps;
        public BrowserDriver _browserDriver;
      
       
        [Obsolete]
        public VerifypayeenamErrorMessageTestSteps()
        {
            _addnewpayeeteststeps = new AddNewPayeeTestSteps();
       
            _browserDriver = new BrowserDriver();
        }

        [Obsolete]
        public void VerifyErrorMessageSteps(Hashtable ht)
        {
            _addnewpayeeteststeps.NavigatetoPayeeDetailsPage();
            _addnewpayeeteststeps.EnterBlankPayeeNameAndClickAddSteps("");
            _addnewpayeeteststeps.ValidateErrorMessage("Payee Name is a required field. Please complete to continue.");
            _addnewpayeeteststeps.EnterAllMandatoryFieldsSteps("Demo5",ht);
            _addnewpayeeteststeps.ValidateErrorMessage("");
         
        }

        public void BrowserDispose()
        {
            _browserDriver.Dispose();
        }
    }
}
