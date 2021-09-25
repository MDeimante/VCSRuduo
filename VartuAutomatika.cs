using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation
{
    public class VartuAutomatika
    {

        public static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://vartutechnika.lt/");
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.Id("cookiescript_reject")).Click(); //del cookio kuris uzstoja calculate button
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }


        [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000 x 2000 + Vartu atuomatika = 665.98€")]
        [TestCase("4000", "2000", true, true, "1006.43€", TestName = "4000 x 2000 + Vartu atuomatika + Vartu montavimo darbai = 1006.46€")]
        [TestCase("4000", "2000", false, false, "692.35€", TestName = "4000 x 2000 = 665.98€")]
        [TestCase("5000", "2000", false, true, "989.21€", TestName = "5000 x 2000 + Vartu montavimo darbai = 989.21€")]


        public static void TestVartuAutomatika(string width, string hight, bool automatika, bool montavimoDarbai, string result);
        {
        IWebElement widthInput = _driver.FindElement(By.Id("doors_width"));
        widthInput.Clear();
        widhInput.SendKeys(width);

        IWebElement hightInput = _driver.FindElement(By.Id("doors_width"));
        widthInput.Clear();
        widhInput.SendKeys(width);

        IWebElement autoCheckBox1 = _driver.FindElement(By.Id("automatika"));

           if(automatika != autoCheckBox.Selected) //jei varut automatika mygtukas nepaspaustas
            {
            autoCheck.Box.Click();
            }


        IWebElement autoCheckBox2 = _driver.FindElement(By.Id("darbai"));

          if(MontavimoDarbai != autoCheckBox2.Selected) //jei vartu automatika mygtukas nepaspaustas
            {
            autoCheck.Box2.Click();
            }


        IWebElement calculateButton = _driver.FindElement(By.Id("calc_submit"));
        calculateButton.Click();
    }
}