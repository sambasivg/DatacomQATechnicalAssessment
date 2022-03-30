using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesScriptsDemo.Report;
using TesScriptsDemo.TestSteps;

namespace TesScriptsDemo.TestScripts
{
    [TestClass]
    public class VerifyPayeeNameErrorMessageTestScript
    {


        public TestContext testContextInstance;
        public static string TestCaseName = "";
        public static string TestResultsDiretory = "";
        public TestReport report;
        public VerifypayeenamErrorMessageTestSteps _verifyPayeeNameErrorMessageTestSteps;
        public string StartTime;
        [Obsolete]
        

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
        public void VerifyPayeeNameErrorMessage()
        {
            string TestResultfilePath;
            TestCaseName = TestContext.TestName;
            TestResultsDiretory = TestContext.TestRunResultsDirectory;
            Hashtable ht = new Hashtable();
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

            report = new TestReport();
                report.ReportInit();
                report.WriteTeststepsHeading("", "", "");
                _verifyPayeeNameErrorMessageTestSteps = new VerifypayeenamErrorMessageTestSteps();
                _verifyPayeeNameErrorMessageTestSteps.VerifyErrorMessageSteps(ht);
                 _verifyPayeeNameErrorMessageTestSteps.BrowserDispose();
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


