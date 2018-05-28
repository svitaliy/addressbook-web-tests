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
    public class GruopCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData ("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();

            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "ccc";
            FillGroupForm(group);

            SubmitGroupCreation();
            ReturnToGroupPage();
        }
      
        
    }
}
