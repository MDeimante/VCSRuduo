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
    public class CheckboxDemo
    {
        public static IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
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

        [Test]
        public static void TestSingleCheckboxDemo()
        {
            IWebElement singleCheckbox = _driver.FindElement(By.Id("isAgeSelected"));
            singleCheckbox.Click();

            IWebElement singleCheckboxResult = _driver.FindElement(By.Id("txtAge"));
            Assert.IsTrue(singleCheckboxResult.Text.Contains("Success"));

        }

        [Test]
        public static void TestMultipleCheckBox() //kadangi multiple checkboxai turi vienoda klase, pgl kuria identifikuojam,
            //tai tokiu atveju naudosim web.Driver.FindElements (daugiskaita) = 
        {
            IReadOnlyCollection<IWebElement> multipleCheckBoxes = _driver.FindElements(By.ClassName("cb1-element"));
            //tuomet su jais naudojam cikla for/for each
            foreach (IWebElement checkBox in multipleCheckBoxes) //reikia kad iteruotu/eitu per kiekviena elementa:
            {
                if (!checkBox.Selected) //jei NEpazymetas langelis
                {
                    checkBox.Click();
                }
            }
        }
        [Test]
        public static void TestButton()
        {
            IWebElement button = _driver.FindElement(By.CssSelector("#check1"));//isemem value t.y. pgl atributa
            if(button.GetAttribute("value").Equals("Check All"))
            {
                button.Click();
            }

        }


    }
}
