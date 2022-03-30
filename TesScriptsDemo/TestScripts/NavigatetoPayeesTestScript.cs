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

using EnvDTE80;

using System.Runtime.InteropServices;

namespace TesScriptsDemo.TesScripts
{
    [TestClass]
    public class NavigatetoPayeesTestScript
    {
        public TestContext testContextInstance;
        public static string TestCaseName = "";
        public static string TestResultsDiretory = "";
        public TestReport report;
        public NavigatetoPayeesTestSteps _navpayeestesps;
        public static string StartTime;
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
        public void NavigatetoPayee()
        {
            string fileName = "\\TesScriptsDemo\\.runsettings";
            string path1 = "TestResults";
            string path2 = @"\mydir";
            string TestResultfilePath;

            TestCaseName = TestContext.TestName;

            TestResultfilePath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\TestResults\\"+ TestCaseName;
            if (!(Directory.Exists(TestResultfilePath)))
            {
                Directory.CreateDirectory(TestResultfilePath);
            }
            TestResultsDiretory = TestContext.TestRunResultsDirectory;
            StartTime = DateTime.Today.ToString("dd-MM-yyyy") + DateTime.Now.ToString("HH:mm:ss");
            StartTime = (StartTime.Replace("-", "")).Replace(":", "");
            TestReport.FilePath = TestResultfilePath + "\\" + TestCaseName + "TestCasesResults" + StartTime+ "Report.html";
            TestReport.TCFilePath = TestResultfilePath + "\\" + TestCaseName + "TestSteps" + StartTime+".html";
            TestReport.FilePath.Replace(" ", "");
            TestReport.TCFilePath.Replace(" ", "");
                
                report = new TestReport();
                report.ReportInit();
                Console.WriteLine("Test Case name:" + NavigatetoPayeesTestScript.TestCaseName + "test Results Directory" + TestReport.TCFilePath);

                report.WriteTeststepsHeading("", "", "");
                TestCaseName = TestContext.TestName;
                _navpayeestesps = new NavigatetoPayeesTestSteps();
                _navpayeestesps.NavigatetoPayeesSteps();
                _navpayeestesps.BrowserDispose();
               
             
                report.WriteFinalTestStepsResulsReport();
                if (TestReport.TCStepFail >= 1)
                {
                    report.TestcaseFailReport(TestReport.FilePath, TestContext.TestName);
                }
                else
                {
                    report.TestcasePassReport(TestReport.FilePath, TestContext.TestName);
                }
            }

        }
  }



    

