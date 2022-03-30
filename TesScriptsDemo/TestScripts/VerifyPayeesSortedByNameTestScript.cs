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
    public class VerifyPayeesSortedByNameTestScript
    {

        public TestContext testContextInstance;
        public static string TestCaseName = "";
        public static string TestResultsDiretory = "";
        public TestReport report;
        public VerifyPayeesSortedByNameTestSteps _verifyPayeesSortedByNameTestSteps;
        public string StartTime;


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
        public void VerifyPayeesSortedByNameTest()
        {
            string TestResultfilePath;
            TestCaseName = TestContext.TestName;
            TestResultsDiretory = TestContext.TestRunResultsDirectory;

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
                _verifyPayeesSortedByNameTestSteps = new VerifyPayeesSortedByNameTestSteps();
                _verifyPayeesSortedByNameTestSteps.VerifyPayeesNamesSorted();
                _verifyPayeesSortedByNameTestSteps.BrowserDispose();


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

