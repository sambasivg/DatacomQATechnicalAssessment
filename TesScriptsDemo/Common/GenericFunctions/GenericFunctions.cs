using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;

using System.Threading;
using FluentAssertions;
using TesScriptsDemo.BaseDrivers;
using TesScriptsDemo.Report;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TesScriptsDemo.Common.GenericFunctions
{
    public class GenericFunctions
    {
        public IWebDriver _webDriver;
        public BrowserDriver _browserDriver;
        private readonly BrowserDriverFactory _browserDriverFactory;
        private readonly IConfiguration _config;
        private readonly TestReport _report;
        private readonly WebDriverWait _wait;
        // private readonly GenericFunctions _genericFunctions;

        public GenericFunctions()
        {
            _browserDriver = new BrowserDriver();

            _report = new TestReport();
        }



        public void AcceptAlerts(string ExpectedAlertText)
        {

            var alert_win = _browserDriver.Current.SwitchTo().Alert();
            string ActualText = alert_win.Text;
            if (ActualText.Contains(ExpectedAlertText))
                alert_win.Accept();
        }

        public IWebElement FindWebElement(string Property, string PropertyVal)
        {
            IWebElement webele = null;
            try
            {

                switch (Property)
                {
                    case "ID":
                        By EleById = By.Id(PropertyVal);
                        webele = _browserDriver.Current.FindElement(EleById);
                        break;
                    case "NAME":
                        By EleByName = By.Name(PropertyVal);
                        webele = _browserDriver.Current.FindElement(EleByName);
                        break;
                    case "CLASSNAME":
                        By EleByClassName = By.ClassName(PropertyVal);
                        webele = _browserDriver.Current.FindElement(EleByClassName);
                        break;
                    case "TAGNAME":
                        By EleByTagName = By.TagName(PropertyVal);
                        webele = _browserDriver.Current.FindElement(EleByTagName);
                        break;
                    case "CSSSElECTOR":
                        By EleByCssSelector = By.CssSelector(PropertyVal);
                        webele = _browserDriver.Current.FindElement(EleByCssSelector);
                        break;
                    case "XPATH":
                        By EleByXPath = By.XPath(PropertyVal);
                        webele = _browserDriver.Current.FindElement(EleByXPath);
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return webele;
        }

        public IList<IWebElement> FindWebElements(string Property, string PropertyVal)
        {
            IList<IWebElement> webele = null;
            try
            {
                switch (Property)
                {
                    case "ID":
                        By EleById = By.Id(PropertyVal);
                        webele = _browserDriver.Current.FindElements(EleById);
                        break;
                    case "NAME":
                        By EleByName = By.Name(PropertyVal);
                        webele = _browserDriver.Current.FindElements(EleByName);
                        break;
                    case "CLASSNAME":
                        By EleByClassName = By.ClassName(PropertyVal);
                        webele = _browserDriver.Current.FindElements(EleByClassName);
                        break;
                    case "TAGNAME":
                        By EleByTagName = By.TagName(PropertyVal);
                        webele = _browserDriver.Current.FindElements(EleByTagName);
                        break;
                    case "CSSSElECTOR":
                        By EleByCssSelector = By.CssSelector(PropertyVal);
                        webele = _browserDriver.Current.FindElements(EleByCssSelector);
                        break;
                    case "XPATH":
                        By EleByXPath = By.XPath(PropertyVal);
                        webele = _browserDriver.Current.FindElements(EleByXPath);
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return webele;
        }

        [Obsolete]
        public void Click_Webelement(string property, string propertyval, string Action)
        {
            _browserDriver.WaitUntilClickable(propertyval);

            try
            {
                IWebElement webele = FindWebElement(property, propertyval);
                if (webele.Displayed)
                {
                     webele.Click();
                    _report.WriteTeststepsPassMessage(Action, ":" + "Element  Found", propertyval + propertyval + ".png");
                }
                else
                {
                    _report.WriteTeststepsFailMessage("Element", "Not Found", "");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void EnterValue_InWebelement(string property, string propertyval, string value)
        {
            try
            {
                IWebElement webele = FindWebElement(property, propertyval);
                if (webele.Displayed)
                {
                    webele.SendKeys(value);
                    _report.WriteTeststepsPassMessage("Enter Value", value + "Element  Found", propertyval + propertyval + ".png");
                }
                else
                {
                    _report.WriteTeststepsFailMessage("Element", "Not Found", "");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void EnterValue_InWebelementAndHitEnter(string property, string propertyval, string value)
        {
            try
            {
                IWebElement webele = FindWebElement(property, propertyval);
                if (webele.Displayed)
                {
                    webele.Click();
                    webele.SendKeys(value);
                    webele.SendKeys(Keys.Enter);
                    _report.WriteTeststepsPassMessage("Enter Value", value + "Element  Found", propertyval + propertyval + ".png");
                }
                else
                {
                    _report.WriteTeststepsFailMessage("Element", "Not Found", "");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void EnterValue_InWebelementAndHitTAB(string property, string propertyval, string value)
        {
            try
            {
                IWebElement webele = FindWebElement(property, propertyval);
                if (webele.Displayed)
                {
                    webele.Click();
                    webele.SendKeys(value);
                    webele.SendKeys(Keys.Tab);
                    _report.WriteTeststepsPassMessage("Enter Value", value + "Element  Found", propertyval + propertyval + ".png");
                }
                else
                {
                    _report.WriteTeststepsFailMessage("Element", "Not Found", "");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Obsolete]
        public void ValidateElementExistOrNot(string property, string propertyval, string value)
        {
            IList<IWebElement> webele = FindWebElements(property, propertyval);

            try
            {
                if (webele.Count == 1)
                {

                    _browserDriver.WaitUntilTextpresent(webele[0], value);

                    webele[0].Displayed.Should().BeTrue();
                    webele[0].Text.Equals(value);
                    Console.WriteLine("Actual Value:" + webele[0].Text + "Expected Value:" + value + "Are identical" + propertyval + propertyval + ".png");
                    _report.WriteTeststepsPassMessage("Actual Value:" + webele[0].Text, "Expected Value:" + value + "Are identical", propertyval + propertyval + ".png");
                }
                else
                {
                    _report.WriteTeststepsFailMessage("Actual Value:" + webele[0].Text, "Expected Value:" + value + "Are Not identical", propertyval + "temp.png");


                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public void AssertValues(string expected, string actual, string description)
        {
            if (expected.Equals(actual))
            {
                _report.WriteTeststepsPassMessage("Actual Value:" + actual, "Expected Value:" + expected + "Are identical", description + ".png");
            }
            else
            {
                _report.WriteTeststepsFailMessage("Actual Value:" + actual, "Expected Value:" + expected + "Are Not identical", description + "temp.png");
                Assert.AreEqual(expected,actual);
            }
        }

        //Asserts that the lists elements and the order
        public void AssertList(List<string> expected, List<string> actual, string description)
        {
            if (string.Join(",", expected.ToArray()).Equals(string.Join(",", actual.ToArray())))
            {
                _report.WriteTeststepsPassMessage("Actual Value:" + actual, "Expected Value:" + expected + "Are identical", description + ".png");
            }
            else
            {
                _report.WriteTeststepsFailMessage("Actual Value:" + actual, "Expected Value:" + expected + "Are Not identical", description + "temp.png");
                Assert.AreEqual(string.Join(",", expected.ToArray()), string.Join(",", actual.ToArray()));
            }
        }
    }
}

    

