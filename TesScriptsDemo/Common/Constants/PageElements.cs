namespace TesScriptsDemo.Common.Constants
{
    public class PageElements
        {
            public static class HOMEPAGE
            {
                public const string MENU_XPATH = "//*[@id='left']//span[text()='Menu']";
                public const string MenuText_Xpath = "//*[@id='left']//span[text()='International']";
                public const string AccountBalance_XPATH = "//h3[contains(text(),'{0}')]/ancestor::div[@class='account-info']";///span[contains(@class,'account-balance')]";
            }
        public static class PAYEEPAGE
        {
            public const string PAYESS_XPATH = "//*[@id='left']//span[text()='Payees']";
            public const string PAYEESPAGETITLE_Xpath = "//*[@id='YouMoney']//span[text()='Payees']";
            public const string PAYEENAME_XPATH = "//span[text()='Name']";

        }

        public static class ADDNEWPAYEE
        {
            public const string ADDBtn_XPATH = "//*[@id='YouMoney']//button//span[text()='Add']";
            public const string PayeeName_XPATH = "//*[@id='ComboboxInput-apm-name']";
            public const string AccntNumberBank_XPATH = "//*[@id='apm-bank']";
            public const string AccntNumberBranch_XPATH = "//*[@id='apm-branch']";
            public const string AccntNumberAccntNum_XPATH = "//*[@id='apm-account']";
            public const string AccntNumberSuffix_XPATH = "//*[@id='apm-suffix']";
            public const string AddNewPayeeBtn_XPATH = "//*[@id='apm-form']/div[2]/button[3]";
            public const string VerifyPayeeAddedMsg_XPATH = "//*[@id='notification']//span[text()='Payee added']";
            public const string PayeeGrid_XPATH = "//*[@id='YouMoney']//ul[contains(normalize-space(@class),'List List--border')]//li";
                //"//span[contains(@class,'payee-name')]";
        }
        public static class PAYMENTPAGE
        {
            public const string PayOrTransfer_XPATH = "//*[@id='left']//span[text()='Pay or transfer']";
            public const string FromAccountChoser_XPATH = ".//button[@data-testid ='from-account-chooser']";
            public const string Account_XPATH = "//button[descendant::img[contains(@alt,'{0}')]]";
            public const string ToAccountChoser_XPATH = ".//button[@data-testid ='to-account-chooser']";
            public const string AccountsTab_XPATH = "//li[@data-testid='to-account-accounts-tab']//span[text()='Accounts']";
            //public const string BillsAccount_XPATH = "//button[descendant::img[@alt='Bills ']]";
            public const string Amount_XPATH = "//input[@name='amount']";
            public const string TransferBtn_XPATH = "//*[@id='paymentForm']//span[text()='Transfer']";
            public const string BillsBalance_XPATH = "//h3[text()='Bills ']/ancestor::div[@class='account-info']/span[contains(@class,'account-balance')]";
        }
      
        }
}
