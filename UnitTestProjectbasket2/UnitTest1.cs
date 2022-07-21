using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace UnitTestProjectbasket2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1(String wordToSearch)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trendyol.com/");
            //en fazla 10 saniye olacak şekilde bekleyecek nesnemizi tanımladık
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            driver.FindElement(By.ClassName("search-box")).SendKeys(wordToSearch + Keys.Enter);
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='search-app']/div/div[1]/div[2]/div[5]/div/div[2]/div[1]/a")));
            String str = driver.FindElement(By.XPath("//*[@id='search-app']/div/div[1]/div[2]/div[5]/div/div[2]/div[1]/a")).GetAttribute("href");
            driver.Navigate().GoToUrl(str);
            //sepete ekle butonu yaratılana kadar bekliyor
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("add-to-basket")));
            //sepete ekleniyor
            driver.FindElement(By.ClassName("add-to-basket")).Click();
            //sepetime gidiliyor
            driver.FindElement(By.XPath("//*[@id='account-navigation-container']/div/div[2]/a")).Click();
            //silme butonu tıklanabilir olana kadar bekleniyor.
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='pb-container']/div/div[3]/div[3]/div[3]/button")));
            //sepetten sile tıklanıyor
            driver.FindElement((By.XPath("//*[@id='pb-container']/div/div[3]/div[3]/div[3]/button"))).Click();
            //çıkacak olan Pop-up beklenip silmeye onay veriliyor.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pb-container']/div/div[3]/div[3]/div/div[3]/div/button[2]")));
            driver.FindElement((By.XPath("//*[@id='pb-container']/div/div[3]/div[3]/div/div[3]/div/button[2]"))).Click();
            Console.WriteLine("test başarılı");
            Console.ReadKey();
            driver.Quit();
        }
    }
}
