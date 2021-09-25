using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation
{
    class SkirtingosNarsykles
    {
        [Test]
        public static void TestFireFoxDriver()
        {
            IWebDriver driver = new FireFoxDriver();
            driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes";
            driver.Manage().Window.Maximize();
            driver.Quit();
        }
    }
}
