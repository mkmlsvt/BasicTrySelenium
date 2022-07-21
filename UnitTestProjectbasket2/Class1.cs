using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UnitTestProjectbasket2
{
    static class Program
    {
        static void Main()
        {
            UnitTest1 unitTest1 = new UnitTest1();
            Console.WriteLine("aranacak kelimeyi girin");
            string wordToSearch = Console.ReadLine();
            unitTest1.TestMethod1(wordToSearch);         
        }
    }
}
