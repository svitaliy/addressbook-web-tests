using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]                       //аттрибуты (каждый фреймворк имеет свои аттрибуты), метки
    public class GruopCreationTests
    {
        private IWebDriver driver;                         //поля private - модификарот видимости IWebDriver - тип поля  driver - название поля
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()                     //методы (содержит програмный код)  public-модификатор видимости void-тип возвращаемого значения SetupTest - имя метода () 
        {
            FirefoxOptions options = new FirefoxOptions(); //создаем объект типа FirefoxOptions
            options.UseLegacyImplementation = true; // в этом объекте указываеем что используем старый способ запуска, т.к. установлен браузер старой версии (браузер стабильно работающей версии)
            options.BrowserExecutableLocation = @"C:\Users\vitaliy.s\Downloads\FirefoxPortableESR\FirefoxPortable.exe"; // указываем путь к этомй старому браузеру

            driver = new FirefoxDriver(options); // инициализируем драйвер браузера и передаем объект (options) в конструктор драйвера
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login();
            GoToGroupPage();
            InitNewGroupCreation();
            FillGroupForm();
            SubmitGroupCreation();
            ReturnToGroupPage();
        }

        private void ReturnToGroupPage()
        {
            
            driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void SubmitGroupCreation()
        {
            
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm()
        {
            
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys("fg");
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys("fg");
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys("gf");
        }

        private void InitNewGroupCreation()
        {
            
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupPage()
        {
            
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login()
        {
            
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys("admin");
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys("secret");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void OpenHomePage()
        {
            
            driver.Navigate().GoToUrl(baseURL + "addressbook/group.php");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
