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
    public class NamuDarbasPerdarytas3in1
    {
    public IWebDriver _driver;
        private static object actualResult;

        [OneTimeSetUp] 
        public void SetUp() 
        {
            IWebDriver _driver = new ChromeDriver(); //sita kintamaji iskelsim pries klase globaliai, nes jis naudojamas visur
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            IWebElement popup = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            wait.Until(e => e.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            popup.Click();
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }

        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")] //test case anotacija, nuroodme kintamuosius ir su kuo lyginam
        [TestCase("-5", "3", "-2", TestName = "-5 + r = -2")]
        [TestCase("a", "b", "NaN", TestName = "a + b = NaN")]
        
        public void TestSum(string firstValue, string secondValue, string expectedResult)
   
        {
           //apsirasom kintamuosius, kuriu ieskosim t.y. laukai 1 ir 2 bei ka i juos ivesim:
            IWebElement firstInput = _driver.FindElement(By.Id("sum1"));
            firstInput.Clear();
            firstInput.SendKeys(firstValue);
            

            IWebElement secondInput = _driver.FindElement(By.Id("sum2"));
            secondInput.SendKeys(secondValue);

            IWebElement GetTotalButton = _driver.FindElement(By.CssSelector("gettotal > button"));
            GetTotalButton.Click();

            IWebElement actualResult = _driver.FindElement(By.CssSelector("displayvalue"));
            Assert.AreEqual(expectedResult, actualResult.Text, "wrong result");

        }
    }

    internal class OneTimeTearDownAttribute : Attribute
    {
    }
}
