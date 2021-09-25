using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Page;

namespace TestAutomation.Tests
{
    public class InputTest
    {
        public static IWebDriver _driver;
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
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }
        //APJUNGIAM TEST IR PAGE folderius: tiesiog atliekam funkcijas:
        [Test]
        public static void TestInputField()
        {
            InputPage page = new InputPage(_driver);
            string text = "Penktadienis";

            page.InsertTextToInputField(text);
            page.ClickShowMessageButton();
            page.VerifyResult(text);
        }


    }
}
