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
    class Class2
    {
        [Test]
        public static void Paskaita2()
        {
            // sulaukti elemento pvz popup: driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // webDriver.Manage().Window.Maximize(); padidinti langa
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            


        }

    }
}
