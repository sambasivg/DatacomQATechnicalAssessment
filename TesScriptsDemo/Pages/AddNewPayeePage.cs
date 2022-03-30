using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesScriptsDemo.Common.Constants;
using TesScriptsDemo.Common.GenericFunctions;

namespace TesScriptsDemo.Pages
{
    [Obsolete]
    public class AddNewPayeePage : BasePage
    {

        [Obsolete]
        public GenericFunctions _genericfucntions;
        public AddNewPayeePage()
        {
           // LaunchApplication();
            _genericfucntions = new GenericFunctions();
        }

        public void ClickOnAddButton()
        {
            _browserdriver.WaitUntilVisible(PageElements.ADDNEWPAYEE.ADDBtn_XPATH);
            _genericfucntions.Click_Webelement("XPATH", PageElements.ADDNEWPAYEE.ADDBtn_XPATH, "Click On Add Button In Payees Page");
            MoveToCurrentWindow();
           // PageElements.ADDNEWPAYEE.PayeeName_XPATH
        }
        public void EnterBankAccountNumber(Hashtable newpayeeData)
        {

            
            _genericfucntions.EnterValue_InWebelementAndHitTAB("XPATH", PageElements.ADDNEWPAYEE.AccntNumberBank_XPATH, Convert.ToString(newpayeeData["Bank"]));
            _genericfucntions.EnterValue_InWebelementAndHitTAB("XPATH", PageElements.ADDNEWPAYEE.AccntNumberBranch_XPATH, Convert.ToString(newpayeeData["Branch"]));
            _genericfucntions.EnterValue_InWebelementAndHitTAB("XPATH", PageElements.ADDNEWPAYEE.AccntNumberAccntNum_XPATH, Convert.ToString(newpayeeData["AccntNum"]));
            _genericfucntions.EnterValue_InWebelementAndHitTAB("XPATH", PageElements.ADDNEWPAYEE.AccntNumberSuffix_XPATH, Convert.ToString(newpayeeData["Suffix"]));
            
        }

        public void EnterPayeeName(string newpayeeData)
        {
            MoveToCurrentWindow();
            _browserdriver.WaitUntilVisible(PageElements.ADDNEWPAYEE.PayeeName_XPATH);
            _genericfucntions.EnterValue_InWebelementAndHitEnter("XPATH", PageElements.ADDNEWPAYEE.PayeeName_XPATH, newpayeeData);
        }

        public void ClickAddNewPayeeBtn()
        {
            _browserdriver.WaitUntilClickable(PageElements.ADDNEWPAYEE.AddNewPayeeBtn_XPATH);
            _genericfucntions.Click_Webelement("XPATH", PageElements.ADDNEWPAYEE.AddNewPayeeBtn_XPATH, "Click On Add NewPayee Button  Page");
           _browserdriver.WaitUntilVisible(PageElements.ADDNEWPAYEE.ADDBtn_XPATH);

           
            
        }
        public void VerifyPayeeSuccessFullyAddedMessage(string expecmsg)
        {
            _browserdriver.WaitUntilVisible(PageElements.ADDNEWPAYEE.VerifyPayeeAddedMsg_XPATH);
            _genericfucntions.AssertValues("Payee added", _browserdriver.Current.FindElement(By.XPath(PageElements.ADDNEWPAYEE.VerifyPayeeAddedMsg_XPATH)).Text, "Payee Addeded");
            _genericfucntions.AssertValues(expecmsg, _browserdriver.Current.FindElement(By.XPath(PageElements.ADDNEWPAYEE.PayeeGrid_XPATH + "//span[text()='" + expecmsg + "']")).Text, "Payee" + expecmsg + "found");
        }

        public void VerifyErrorMessage(String expecmsg)
        {
            string actualmsg = _browserdriver.Current.FindElement(By.XPath(PageElements.ADDNEWPAYEE.PayeeName_XPATH)).GetAttribute("aria-label");
            actualmsg = actualmsg == null ? "":actualmsg;
            _genericfucntions.AssertValues(expecmsg.Trim(),actualmsg, "PayeeNameValidation");            
        }
    }
    
}
