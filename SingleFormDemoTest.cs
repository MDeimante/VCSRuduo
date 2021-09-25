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
    public class SingleFormDemoTest
    {
        [Test] //TIKRINAM VIENO LAUKO IVEDIMA
        public static void TestSingleInputField()
        { 
            IWebDriver driver = new ChromeDriver(); //1. nueinam i tinklapi
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html"; 
            driver.Manage().Window.Maximize();
            //2 apsirasom kintamaji kurio ieskosim:
            IWebElement inputField; //arba iskart IWebElement inputField = driver.FindElement(By.Id("user-message"));
            //3 tinklapyje ranka spaudziam desini klavisa ant norimo elemento ir pasirenkam INSPECT
            //4 identifikuojam ID kodo eiluteje siuo atveju id="user message"
            //5 liepiam kodui surasti elementa pagal id:
            inputField = driver.FindElement(By.Id("user-message"));
            //aprasom dar viena kintamaji t.y. teksta, kuri siusim i langeli:
            string myText = "Hello";
            //siunciam teksta i langeli:
            inputField.SendKeys(myText);

            //ieskom kito langelio show message. tinklapyje spaudziam inspect. nera ID, todel,
            // spaudziam des. klavisa ant eilutes kode, copy --> copy selector:
            IWebElement showMessageButton = driver.FindElement(By.CssSelector("#get-input > button")); //ikopijuotas tekstas kabutese
            //ka su tuo elementu darom? reikia paspausti:
            showMessageButton.Click();


            //Jei issoka koks pupuo ir del to negalima padaryti testo ir paspausti showmessage button,
            //tada pirmiausia isjungiam mygtuka:
            // IWebElement pupup = driver.FindElement(By.Id("at-cv-lightbox-close"));
            // pupup.Click();


            //tikrinam, ar rodomas tekstas toks, koki ivedem, ar actual result yra kaip expected result:
            //tinklapyje ant rodomo zodzio spaudziam des. peles klavisa, inspect, ieskom id="display"

            IWebElement actualResultText = driver.FindElement(By.Id("display"));
            //tikrinam expected vs actual result:
            Assert.AreEqual(myText, actualResultText.Text, "text is different");//+formatuojam i teksta
            //arba Assert.IsTrue(actualResultText.Text.Contains(myText), "Text is different");

            //UZDARO DRIVER'I:
            driver.Quit();

           
        }
    }
}
