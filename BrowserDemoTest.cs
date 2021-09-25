using NUnit.Core;
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
    public class BrowserDemoTest
    {
        private static IWebDriver _driver;

        [TearDown] //o ne one time tear down, nes cia yra test case;ai
        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase("chrome", TestName = "TestingChrome")]
        [TestCase("firefox", TestName = "TestingFirefox")]

        public static void TestBrowser(string browser)
        {
            if ("Chrome".Equals(browser))
                _driver = new ChromeDriver();
            if ("Firefox".Equals(browser))
                _driver = new FireFoxDriver();

            _driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes.html");

            IWebElement actualResult = _driver.FindElement(By.CssSelector("#primary-detection > div"));
            Assert.IsTrue(actualResult.Text.Contains(browser), $"Browser is not {browser}");
        }
    }
}
