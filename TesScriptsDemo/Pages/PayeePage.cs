using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesScriptsDemo.BaseDrivers;
using TesScriptsDemo.Common;
using TesScriptsDemo.Common.Constants;
using TesScriptsDemo.Common.GenericFunctions;

namespace TesScriptsDemo.Pages
{
    [Obsolete]
    public class PayeePage : BasePage
    {
        [Obsolete]
        public GenericFunctions _genericfucntions;
        public PayeePage()
        {
           
            _genericfucntions = new GenericFunctions();
        }


        public void ClickOnMenu()
        {
            _browserdriver.WaitUntilVisible(PageElements.HOMEPAGE.MENU_XPATH);
            _browserdriver.GetWebDriverWait();
            _genericfucntions.Click_Webelement("XPATH", PageElements.HOMEPAGE.MENU_XPATH,"Click On Menu");
           }
        public void ClickOnPayeeLink()
        {
         
            _browserdriver.WaitUntilVisible(PageElements.PAYEEPAGE.PAYESS_XPATH);
            _genericfucntions.Click_Webelement("XPATH", PageElements.PAYEEPAGE.PAYESS_XPATH,"Click On Payee");
            _browserdriver.WaitUntilElementPresent(PageElements.PAYEEPAGE.PAYEESPAGETITLE_Xpath);
            _genericfucntions.AssertValues("Payees",_browserdriver.Current.FindElement(By.XPath(PageElements.PAYEEPAGE.PAYEESPAGETITLE_Xpath)).Text,"PayeesPage");
        }
        public void init()
        {
            Console.WriteLine("Navigate to PayeePage");
        }

        public void VerifyPayeeSortByName()
        {
            //Get the payeename list
            List<string> allPayeeNames = new List<string>(_browserdriver.Current.FindElements(By.XPath(PageElements.ADDNEWPAYEE.PayeeGrid_XPATH + "//span[contains(@class,'payee-name')]")).Select(iw => iw.Text));
            List<String> sortedPayeeList = allPayeeNames;
            sortedPayeeList.Sort();

            //Compare the list from the page with the sorted list
            _genericfucntions.AssertList(sortedPayeeList, allPayeeNames, "PayeeNames");
            
            //Click Name column sort
            _genericfucntions.Click_Webelement("XPATH", PageElements.PAYEEPAGE.PAYEENAME_XPATH, "Click on Payee Name");
            
            //Retrieve the names from the Payee Grid after sort
            allPayeeNames = new List<string>(_browserdriver.Current.FindElements(By.XPath(PageElements.ADDNEWPAYEE.PayeeGrid_XPATH + "//span[contains(@class,'payee-name')]")).Select(iw => iw.Text));
            sortedPayeeList.Reverse();
            
            //Assert the lists
            _genericfucntions.AssertList(sortedPayeeList, allPayeeNames, "PayeeNames");

        }
    }
}
