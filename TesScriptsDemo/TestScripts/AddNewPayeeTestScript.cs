using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

using System.Data;
using TesScriptsDemo.Report;
using TesScriptsDemo.TestSteps;
using TesScriptsDemo.BaseDrivers;
using System.IO;

namespace TesScriptsDemo.TestScripts
{

    [TestClass]
    public class AddNewPayeeTestScript
    {

        public TestContext testContextInstance;
        public static string TestCaseName = "";
        public static string TestResultsDiretory = "";
        public TestReport report;
        public AddNewPayeeTestSteps _addnewpayeesteps;
        public static string StartTime;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        // NavigateTo Payees Page
        [TestMethod]
        [DeploymentItem(@"Data\\TestData.xml")]
        [DataSource("XMLDataSource")]
        [Obsolete]
        public void AddNewPayees()
        {
            string TestResultfilePath;
            TestCaseName = TestContext.TestName;
            TestResultsDiretory = TestContext.TestRunResultsDirectory;
           
            int iRow = TestContext.DataRow.Table.Rows.IndexOf(TestContext.DataRow);
            if (TestCaseName.Equals("AddNewPayees") && (iRow.Equals(0)))
            {
                TestResultfilePath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\TestResults\\" + TestCaseName;
                if (!(Directory.Exists(TestResultfilePath)))
                {
                    Directory.CreateDirectory(TestResultfilePath);
                }
        
                StartTime = DateTime.Today.ToString("dd-MM-yyyy") + DateTime.Now.ToString("HH:mm:ss");
                StartTime = (StartTime.Replace("-", "")).Replace(":", "");
                TestReport.FilePath = TestResultfilePath + "\\" + TestCaseName + "TestCasesResults" + StartTime + "Report.html";
                TestReport.TCFilePath = TestResultfilePath + "\\" + TestCaseName + "TestSteps" + StartTime + ".html";
                TestReport.FilePath.Replace(" ", "");
                TestReport.TCFilePath.Replace(" ", "");




                Hashtable ht = new Hashtable();
                Console.WriteLine("TestCasename:" + TestCaseName);
                ht.Add("TestCase", TestCaseName);
                string PAYEENAME = TestContext.DataRow["PAYEENAME"].ToString();
                ht.Add("PAYEENAME", PAYEENAME);
                string Bank = TestContext.DataRow["Bank"].ToString();
                ht.Add("Bank", Bank);
                String Branch = TestContext.DataRow["Branch"].ToString();
                ht.Add("Branch", Branch);
                String AccntNum = TestContext.DataRow["AccntNum"].ToString();
                ht.Add("AccntNum", AccntNum);
                String Suffix = TestContext.DataRow["Suffix"].ToString();
                ht.Add("Suffix", Suffix);
                report = new TestReport();
                report.ReportInit();
                report.WriteTeststepsHeading("", "", "");
                _addnewpayeesteps = new AddNewPayeeTestSteps();
                _addnewpayeesteps.AddNewPayeeSteps(ht);
               _addnewpayeesteps.BrowserDispose();

                report.WriteFinalTestStepsResulsReport();
                if (TestReport.TCStepFail >= 1)
                {
                    report.TestcaseFailReport(TestReport.FilePath, TestCaseName);

                }
                else
                {
                    report.TestcasePassReport(TestReport.FilePath, TestCaseName);
                }
            }

        }
    }




}
