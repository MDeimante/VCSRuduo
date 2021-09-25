using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NUnit.Core.NUnitFramework;

namespace TestAutomation.Page
{                           //PAGE OBJECT PATTERN. web pusl traktuojamas kaip klase, o jos laukai - puslapio elementai. klases
                                //metodai - tai veiksmai puslapyje
    public class InputPage
    {
        public static IWebDriver _driver;
        //apsirasom kintamuosius t.y. elementus: 
        private IWebElement _inputField => _driver.FindElement(By.Id("sum1")); //_pradzioje nes elementai globalus siai klasei
        private IWebElement _showMessageButton => _driver.FindElement(By.CssSelector("#get-input > button"));

        private IWebElement _actualResult => _driver.FindElement(By.Id("display"));

        private IWebElement _firstInput =>  _driver.FindElement(By.Id("sum1"));
        //private kad kitos klases nenaudotu.> varnele tam kad sio elemeto ieskotu tik tada kai jo reikia
        private IWebElement _secondInput => _driver.FindElement(By.Id("sum1"));

        private IWebElement _getTotalButton => _driver.FindElement(By.CssSelector("#gettotal > button"));

        private IWebElement _actualSumResult => _driver.FindElement(By.Id("displayvalue"));

        //sukuriam siai klasei konstruktoriu
        public InputPage(IWebDriver webdriver)
        {
            _driver = webdriver; 
        }

        public void InsertTextToInputField(string text)
        {
            _inputField.Clear();
            _inputField.SendKeys(text);
        }

        public void ClickShowMessageButton()
        {
            _showMessageButton.Click();
        }

        //arba ivedam iskart abi reiksmes:
        //public void InsertBothValuesToInputField(string firstValue, string secondValue)
        /*
        {
        InsertTextToTheFirstInputField(firstValue);
         InsertTextToTheSecondInputField(secondValue);
        }
        */

        public void VerifyResult(string result)
        {
            Assert.AreEqual(result, _actualResult.Text, "text is different");
        }
    }
}
