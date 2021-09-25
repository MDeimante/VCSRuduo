using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation
{
    public class NamuDarbaiPaskaita1 // seleniumeasy.com/test/basic-first-form-demo testuojam 2 langelius 
    {
        public IWebDriver _driver; //bruksnelis apacioj kad zinotume, jog cia yra klase

        [OneTimeSetUp] //kas vyksta iki testu
        public void SetUp() //parasius sia kodo dali uz testo ribu, visiems 3 testams ji bus pritaikyta automatiskai
        {
            IWebDriver _driver = new ChromeDriver(); //sita kintamaji iskelsim pries klase globaliai, nes jis naudojamas visur
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            IWebElement popup = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            wait.Until(e => e.FindElement(By.Id("at-cv-lightbox-close")).Displayed;
            popup.Click();
        }

        [OneTimeTearDown] //kas vyks po visu testu
        public void TearDown()
        {
            _driver.Close();

        }

        [Test]
        public static void TestTwoInputField()

        { 
            //apsirasom kintamuosius, kuriu ieskosim t.y. laukai 1 ir 2 bei ka i juos ivesim:
            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            string value1 = "2"; //jei irasau int value1, tuomet value1 SendKeys funkcija nuskaito kaip string
            inputField1.SendKeys(value1);
            int NewValue1 = Convert.ToInt32(value1); //konvertuoju i int cia tuomet

            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            string value2 = "2";
            inputField2.SendKeys(value2);
            int NewValue2 = Convert.ToInt32(value2);

            //ieskom get total mygtuko ir paspaudziam ji:
            IWebElement GetTotalButton = _driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div"));
            GetTotalButton.Click();

            //aprasom expected result:
            int ExpectedResult = NewValue1 + NewValue2;
            //aprasom gauto rezultato eilute (neradau nei id nei classes):
            IWebElement ActualResult = _driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div"));
            //palyginam:
            Assert.AreEqual(ExpectedResult, ActualResult, "wrong result");

            _driver.Quit();
        }

        [Test]
        public static void TestTwoInputField2()
        {
            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            string value1 = "-5"; //jei irasau int value1, tuomet value1 SendKeys funkcija nuskaito kaip string
            inputField1.SendKeys(value1);
            int NewValue1 = Convert.ToInt32(value1); //konvertuoju i int cia tuomet

            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            string value2 = "3";
            inputField2.SendKeys(value2);
            int NewValue2 = Convert.ToInt32(value2);

            IWebElement GetTotalButton = _driver.FindElement(By.ClassName("btn btn - default"));
            GetTotalButton.Click();

            int ExpectedResult = NewValue1 + NewValue2;

            IWebElement ActualResult = _driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div"));
            Assert.AreEqual(ExpectedResult, ActualResult, "wrong result");

        }

        [Test]
        public static void TestTwoInputField3()
        {
            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            string value1 = "A"; 
            inputField1.SendKeys(value1);

            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            string value2 = "B";
            inputField2.SendKeys(value2);

            IWebElement GetTotalButton = _driver.FindElement(By.ClassName("btn btn - default"));
            GetTotalButton.Click();

            IWebElement ActualResult = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN" actualResult.Text, "wrong result");
        }


    }
}