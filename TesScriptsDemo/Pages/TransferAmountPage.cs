using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesScriptsDemo.Common.Constants;
using TesScriptsDemo.Common.GenericFunctions;

namespace TesScriptsDemo.Pages
{
    public class TransferAmountPage :BasePage
    {

        [Obsolete]
        public GenericFunctions _genericfucntions;

        [Obsolete]
        public TransferAmountPage()
        {
            // LaunchApplication();
            _genericfucntions = new GenericFunctions();
        }

        [Obsolete]
        public void ClickOnPayOrTransfer()
        {
            _browserdriver.WaitUntilVisible(PageElements.PAYMENTPAGE.PayOrTransfer_XPATH);
            _genericfucntions.Click_Webelement("XPATH", PageElements.PAYMENTPAGE.PayOrTransfer_XPATH, "Click On Pay or transfer In menu");
            MoveToCurrentWindow();
        }

        [Obsolete]
        public void TransferAmount(string fromAcc,string toAcc,string amt)
        {
            
            //Select From Account
            _genericfucntions.Click_Webelement("XPATH", PageElements.PAYMENTPAGE.FromAccountChoser_XPATH, "Click On From Account button");
            _genericfucntions.Click_Webelement("XPATH", String.Format(PageElements.PAYMENTPAGE.Account_XPATH,fromAcc), "Click On EveryDay Account button");

            //Select To Account
            _genericfucntions.Click_Webelement("XPATH", PageElements.PAYMENTPAGE.ToAccountChoser_XPATH, "Click On To Account button");
            Thread.Sleep(1000);
            _browserdriver.WaitUntilVisible(PageElements.PAYMENTPAGE.AccountsTab_XPATH);
            _genericfucntions.Click_Webelement("XPATH", PageElements.PAYMENTPAGE.AccountsTab_XPATH, "Click On Accounts button");
            _genericfucntions.Click_Webelement("XPATH", String.Format(PageElements.PAYMENTPAGE.Account_XPATH, toAcc), "Click On Bills Account button");
            _browserdriver.WaitUntilVisible(String.Format(PageElements.PAYMENTPAGE.Account_XPATH, fromAcc) + "//p[contains(@class,'balance')]");
             
            //Get Initial Balances
            decimal fromAccBal = GetAccountBalance(PageElements.PAYMENTPAGE.Account_XPATH,fromAcc);
            decimal toAccBal = GetAccountBalance(PageElements.PAYMENTPAGE.Account_XPATH,toAcc);

            //Transfer Amount
            _browserdriver.WaitUntilVisible(PageElements.PAYMENTPAGE.Amount_XPATH);
            _genericfucntions.EnterValue_InWebelement("XPATH", PageElements.PAYMENTPAGE.Amount_XPATH, amt);
            _genericfucntions.Click_Webelement("XPATH", PageElements.PAYMENTPAGE.TransferBtn_XPATH, "Click On Transfer button");
            _browserdriver.WaitUntilVisible(String.Format(PageElements.HOMEPAGE.AccountBalance_XPATH,fromAcc));
            
            //Get Balances Post Transfer
            decimal fromAccBalPostTr = GetAccountBalance(PageElements.HOMEPAGE.AccountBalance_XPATH, fromAcc);// System.Convert.ToDecimal(everydayBalStr, new CultureInfo("en-US"));
            decimal toAccBalPostTr = GetAccountBalance(PageElements.HOMEPAGE.AccountBalance_XPATH, toAcc);
            
            //Assert Transfer
            _genericfucntions.AssertValues((fromAccBal - Convert.ToDecimal(amt)).ToString(), fromAccBalPostTr.ToString(), "Every Day Account Balance Post Transfer");
            _genericfucntions.AssertValues((toAccBal + Convert.ToDecimal(amt)).ToString(), toAccBalPostTr.ToString(), "Bills Account Balance Post Transfer");

        }

        public decimal GetAccountBalance(string balEle, string accName)
        {
            string balStr = _browserdriver.Current.FindElement(By.XPath(String.Format(balEle, accName) + "//*[contains(@class,'balance')]"))
                .Text.Replace("Avl.", "").Replace("$", "").Trim();
            return System.Convert.ToDecimal(balStr, new CultureInfo("en-US"));
        }
    }
}
