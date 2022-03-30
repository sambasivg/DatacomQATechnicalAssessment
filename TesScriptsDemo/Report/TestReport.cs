using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Security.AccessControl;
using TesScriptsDemo.TesScripts;

namespace TesScriptsDemo.Report
{


    public class TestReport
        {
           
            public  static string FilePath;
            public static string TCFilePath;

            public static int TCStepPass = 0;
            public static int TCStepFail = 0;
            public static string StartTime;
            private string TestcaseId;
            private string Scenarioname;
        void InitTestScriptName(String ScenarioName,String Testcaseid)
        {

            TestcaseId = Testcaseid;
            Scenarioname = ScenarioName;
        }
        //Intialize Reporting variables
        //public  TestReport()
         //   {
               // FilePath = NavigatetoPayeesTestScript.TestResultsDiretory + "Scenarioname" + "Report.html";
               
              //  TCFilePath = NavigatetoPayeesTestScript.TestResultsDiretory +"\\"+ NavigatetoPayeesTestScript.TestCaseName + ".html";
               
               
          //  }
            public void ReportInit()
            {
                    WrtiteTestCasesStatus();
                    WriteTeststepsHeading("", "", "");
                    TCStepPass = 0;
                    TCStepFail = 0;
             }



            //Wrtite TestCases Status in Report
            public  void WrtiteTestCasesStatus()
            {
                try
                {
                  
                 
                    // StartTime = DateTime.Today.ToString("dd - MM - yyyy") + DateTime.Now.ToString("HH:mm:ss");

                    using (StreamWriter sr = new StreamWriter(FilePath, false))
                    {
                 
                    sr.WriteLine("<html>");
                        sr.WriteLine("<body bgcolor =" + "#d4d4d4" + ">");
                        sr.WriteLine("<center><h3>SUMMARY REPORT</h3></center>");
                        sr.WriteLine("<hr>");
                        sr.WriteLine("<center><table border=" + 5 + " >");
                        sr.WriteLine("<th width=" + 250 + " ><center>Application Name:</center></th>");
                        sr.WriteLine("<th width=" + 250 + " ><center>" + "BNZDEMO" + "</center></th>");
                        sr.WriteLine("<tr>");
                        sr.WriteLine("<th width=" + 250 + " ><center>Browser Name:</center></th>");
                        sr.WriteLine("<th width=" + 250 + " ><center>" + "IE" + "</center></th>");
                        sr.WriteLine("</center></table border=" + 5 + " >");
                        sr.WriteLine("</tr>");
                        sr.WriteLine("<hr>");
                        sr.WriteLine("<center><table border=" + 5 + " >");
                        sr.WriteLine("<tr>");
                        sr.WriteLine("<th width=" + 250 + " bgcolor =" + "gray" + "><center>TestCase Name</center></th>");
                        sr.WriteLine("<th width=" + 250 + " bgcolor =" + "gray" + "><center>Execution Report PASS/FAIL</center></th>");
                        sr.WriteLine("<th width=" + 250 + " bgcolor =" + "gray" + "><center>Start Date/Time</center></th>");
                        sr.WriteLine("<th width=" + 250 + " bgcolor =" + "gray" + "><center>End Date/Time</center></th>");
                        sr.WriteLine("</tr>");

                   
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("File I/O Exception" + e);
                }

            }

            //Wrtite TestCases Fail reason details in Report
            public  void TestcaseFailReport(String FilePath, String TestCaseID)
            {
                Console.WriteLine("TestcaseFailReport");
                try
                {
                    using (StreamWriter sr = new StreamWriter(FilePath, true))
                    {
                        Console.WriteLine("TestcaseFailReport Start");
                        sr.WriteLine("<td width=" + 50 + "><font><center>" + TestCaseID + "</center></font></td>");
                        sr.WriteLine("<td border=" + 2 + " width=" + 50 + ">"
                            + "<a href="
                            + TCFilePath
                            + "><font color="
                            + "red"
                            + "><b><center>FAIL Report</center></font></a></td>");
                        sr.WriteLine("<td width=" + 150
                                                    + "><font color=" + "black" + ">"
                                                    + TestReport.StartTime
                                                    + "</font></td>");
                        sr.WriteLine("<td width=" + 150
                                                    + "><font color=" + "black" + ">"
                                                    + DateTime.Today.ToString("dd - MM - yyyy") + DateTime.Now.ToString("HH:mm:ss")
                                                    + "</font></td><tr><br></tr>");

                        Console.WriteLine("TestcaseFailReport End");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("File I/O Exception" + e);
                }
            }
            //Wrtite TestCases Pass reason details in  After Create DirectoryWriteTeststepsHeading
            public  void TestcasePassReport(String FilePath, String TestCaseId)
            {
                Console.WriteLine("TestcasepassReport");
                try
                {
                    using (StreamWriter sr = new StreamWriter(FilePath, true))
                    {
                        Console.WriteLine("TestcasepassReport Start");
                        sr.WriteLine("<td width=" + 50 + "><font><center>" + TestCaseId + "</center></font></td>");
                        sr.WriteLine("<td border=" + 2 + " width=" + 50 + ">"
                            + "<a href=" + TCFilePath
                            + "><font color="
                            + "green"
                            + "><b><center>Pass Report</center></font></a></td>");
                        sr.WriteLine("<td width=" + 150
                                                    + "><font color=" + "black" + ">"
                                                    + TestReport.StartTime
                                                    + "</font></td>");
                        sr.WriteLine("<td width=" + 150
                                                    + "><font color=" + "black" + ">"
                                                    + DateTime.Today.ToString("dd - MM - yyyy") + DateTime.Now.ToString("HH:mm:ss")
                                                    + "</font></td><tr><br></tr>");
                        Console.WriteLine("TestcasePassReport End");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("File I/O Exception" + e);
                }
            }
            //Wrtite TestCases Steps details  in Report
            public  void WriteTeststepsHeading(string description, string td, string status)
            {
                try
                {
                    Console.WriteLine("WriteTeststepsHeading Start" + TCFilePath);
                    //  StreamWriter TsH = new StreamWriter(TCFilePath, true);
                    using (StreamWriter TsH = new StreamWriter(TCFilePath, false))
                    {

                        TsH.WriteLine("<html>");
                        TsH.WriteLine("<body bgcolor =" + "#d4d4d4" + ">");
                        TsH.WriteLine("<center><table border=" + 5 + " ><h3>Test Steps Summary Report</h3></center>");
                        TsH.WriteLine("<tr>");
                        TsH.WriteLine("<th width=" + 250 + " bgcolor =" + "gray" + "><center>S.NO</center></th>");
                        TsH.WriteLine("<th width=" + 250 + " bgcolor =" + "gray" + "><center>Test Steps Description</center></th>");
                        TsH.WriteLine("<th width=" + 250 + " bgcolor =" + "gray" + "><center>Test Data</center></th>");
                        TsH.WriteLine("<th width=" + 250 + " bgcolor =" + "gray" + "><center>Status</center></th>");
                        TsH.WriteLine("<th width=" + 250 + " bgcolor =" + "gray" + "><center>Start Date/Time</center></th>");
                        TsH.WriteLine("</tr>");

                        Console.WriteLine("WriteTeststepsHeading End");

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("WriteTeststepsPassMessage:" + e);
                }
            }

            //Wrtite TestCases Steps details  in Report
            public  void WriteTeststepsPassMessage(string description, string td, string scrPath)
            {
                Console.WriteLine("TestStepsStartReport Start");
                try
                {

                    TCStepPass += 1;
                    if (TCStepPass == 1)
                    {
                        StartTime = DateTime.Today.ToString("dd - MM - yyyy") + DateTime.Now.ToString("HH:mm:ss");
                    }

                    using (StreamWriter TsH = new StreamWriter(TCFilePath, true))
                    {

                        TsH.WriteLine("<tr>");
                        TsH.WriteLine("<td width=" + 250 + "><font color=" + "black" + "><center>" + (TCStepPass + TCStepFail) + "</center></td>");
                        TsH.WriteLine("<td width=" + 250 + ">" + description + "</td>");
                        TsH.WriteLine("<td width=" + 250 + ">" + td + "</td>");
                        TsH.WriteLine("<td width=" + 250 + ">"
                            + "<a href=" + scrPath
                            + "><font color=" + "green" + "><center>pass</center></font></a></td>");
                        TsH.WriteLine("<td width=" + 250 + "><center>" + DateTime.Today.ToString("dd - MM - yyyy") + DateTime.Now.ToString("HH:mm:ss") + "</center></td>");
                        TsH.WriteLine("</tr>");

                        Console.WriteLine("TestStepsPassReport End");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("WriteTeststepsPassMessage:" + e);
                }
            }

            //Wrtite TestCases Steps details  in Report
            public  void WriteTeststepsFailMessage(string description, string td, string scrPath)
            {
                Console.WriteLine("TestStepsStartReport Start");
                try
                {

                    TCStepFail += 1;

                    if (TCStepFail == 1)
                    {
                        StartTime = DateTime.Today.ToString("dd - MM - yyyy") + DateTime.Now.ToString("HH:mm:ss");
                    }

                    using (StreamWriter TsH = new StreamWriter(TCFilePath, true))
                    {

                        TsH.WriteLine("<tr>");
                        TsH.WriteLine("<td width=" + 250 + "><font color=" + "black" + "><center>" + (TCStepPass + TCStepFail) + "</center></td>");
                        TsH.WriteLine("<td width=" + 250 + ">" + description + "</td>");
                        TsH.WriteLine("<td width=" + 250 + ">" + td + "</td>");
                        TsH.WriteLine("<td width=" + 250 + ">"
                            + "<a href=" + scrPath
                            + "><font color=" + "Red" + "><center>FAIL</center></font></a></td>");
                        TsH.WriteLine("<td width=" + 250 + "><center>" + DateTime.Today.ToString("dd - MM - yyyy") + DateTime.Now.ToString("HH:mm:ss") + "</center></td>");
                        TsH.WriteLine("</tr>");

                        Console.WriteLine("TestStepsFailReport End");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("WriteTeststepsFailMessage:" + e);
                }
            }

            //Wrtite TestCases Steps Results details  in Report
            public void WriteFinalTestStepsResulsReport()
            {
                using (StreamWriter TsH = new StreamWriter(TCFilePath, true))
                {
                    TsH.WriteLine("<table border=" + 5 + ">");
                    TsH.WriteLine("<tr>");
                    TsH.WriteLine("<br>");
                    TsH.WriteLine("<br>");
                    TsH.WriteLine("<center><h3>EXECUTED TestSteps SUMMARY REPORT</h3></center>");
                    TsH.WriteLine("<th border=" + 5 + " width=" + 200 + " bgcolor =" + "Orange" + "><center>Total No.Of Test Steps Executed</center></th>");
                    TsH.WriteLine("<th border=" + 5 + " width=" + 200 + " bgcolor=" + "green" + "><center></center>Total.No.Of TestSteps Passed</th>");
                    TsH.WriteLine("<th border=" + 5 + " width=" + 200 + " bgcolor=" + "red" + "><center>Total No.Of TestSteps Failed</center></th>");
                    TsH.WriteLine("</tr>");

                    TsH.WriteLine("<tr>");
                    TsH.WriteLine("<td border=" + 5 + " width=" + 200 + "><font><center><h3>" + (TCStepPass + TCStepFail) + "</h3></center></font></td>");
                    TsH.WriteLine("<h3><td border=" + 5 + " width=" + 200 + "><font><center><h3>" + TCStepPass + "</h3></center></font></td>");
                    TsH.WriteLine("<h3><td border=" + 5 + " width=" + 200 + "><font><center><h3>" + TCStepFail + "</h3></center></font></td>");
                    TsH.WriteLine("</tr>");

                    TsH.WriteLine("</table>");
                    TsH.WriteLine("</tr>");
                    TsH.WriteLine("</table>");
                    TsH.WriteLine("</body>");
                    TsH.WriteLine("</html>");
                    TsH.Close();
                }
            }

        }
    }

