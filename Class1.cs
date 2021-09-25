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
    public class Paskaita1 //4 yra lyginis skaicius; dabar yra 16 val
    {
        [Test]
        public static void TestIf4IsEven()
        {
            int leftOver = 4 % 2;
            Assert.AreEqual(0, leftOver, "4 is not even"); //kokio tikimes rez, koks yra is tikruju, zinute
                                                           // jei neatitinka salygos

        }

        [Test]
        public static void TestNowIs16()
        {
            DateTime currentTime;
            currentTime = DateTime.Now; //arba DateTime currentTime = DateTime.Now;
            Assert.AreEqual(16, currentTime.Hour, "Dabar ne 16 valanda");
        }

        [Test]
        public static void Test995Is3()
        {
            int leftOver;
            leftOver = 995 % 3;
            Assert.AreEqual(0, leftOver, "995 nesidalija is 3 be liekanos");
        }


        // IWebDriver - PAGRINDINIS IRANKIS, IMITUOJA NARSYKLE
        [Test]
        public static void TestChromeDriver()  // visas sitas yra metodas!!!! iki driver.Quit 
        {
            IWebDriver driver = new ChromeDriver(); //sukurtas naujas kintamasis dirver, iwebdriver tipo 
            driver.Url = "https://login.yahoo.com/"; //sakom kad driveris eitu i login'a yahoo
            driver.Manage().Window.Maximize(); //kad padidintu langa iki max
            //driver.Quit(); //iseiti is lango
        }


        //IWebElement element - bet koks elementas puslapyje: mygtukai, nuorodos, laukai, sarasai etc
         

    } 
} 


