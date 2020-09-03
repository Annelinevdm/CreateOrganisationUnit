using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using Assert = NUnit.Framework.Assert;

namespace CreateOrganisationUnit
{
    [TestClass]
    public class Tests
    {
        IWebDriver driver = new ChromeDriver(@"C:\\Users\\Anneline\\source\\repos\\");

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://cams.azurewebsites.net/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [TestCase]
        public void Test1()
        {
            //Enter the Login details
            IWebElement UserName = driver.FindElement(By.Id("LoginInput_UserNameOrEmailAddress"));
            UserName.SendKeys("admin");
            IWebElement PassWord = driver.FindElement(By.Id("LoginInput_Password"));
            PassWord.SendKeys("1q2w3E*");
            IWebElement LoginButton2 = driver.FindElement(By.CssSelector("body > div.d-flex.align-items-center > div > div > div > div.card > div.card-body > div > form > button"));
            LoginButton2.Click();

            //Click on Administration
            IWebElement AdminiStration = driver.FindElement(By.XPath("//*[@id='mCSB_1_container']/nav/ul/li[3]/a/span[2]"));
            AdminiStration.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Click on Identity Managment Link
            IWebElement IdManageLink = driver.FindElement(By.XPath("/html/body/header/div/div[2]/div[1]/div/nav/ul/li[3]/ul/li[2]/a/span[2]"));
            IdManageLink.Click();

            //Click on Organisation Unit
            IWebElement OrgUnit = driver.FindElement(By.XPath("/html/body/header/div/div[2]/div[1]/div/nav/ul/li[3]/ul/li[2]/ul/li[1]/a/span[2]"));
            OrgUnit.Click();

            //Click on +Add root unit
            IWebElement AddRootUnit = driver.FindElement(By.Name("CreateOrganizationUnit"));
            AddRootUnit.Click();

            //Add a New Organisation Unit
            IWebElement NewOrgUnit = driver.FindElement(By.Id("OrganizationUnit_DisplayName"));
            NewOrgUnit.SendKeys("A_Test_NewOrganisaton2");
            //Click on the Save button
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("/html/body/div[3]/form/div/div/div/div[3]/button[2]/span"))).Build().Perform();
            IWebElement SaveButton = driver.FindElement(By.XPath("/html/body/div[3]/form/div/div/div/div[3]/button[2]/span"));
            SaveButton.Click();

            //Click on the Organisation Unit added
            Actions action2 = new Actions(driver);
            action2.MoveToElement(driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[1]/div/div/div/div/div/div[1]/ul/li[1]/a/span"))).Build().Perform();
            IWebElement ClickOnOrganisation = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[1]/div/div/div/div/div/div[1]/ul/li[1]/a/span"));

            //Click on the Member button
            IWebElement AddMemberButton = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div/div/div/div/div[1]/div[1]/button/span"));
            AddMemberButton.Click();

            //Select Users
            IWebElement SelectUser = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/div/div/div/div/div[3]/div[2]/table/tbody/tr[1]/td[2]"));
            SelectUser.Click();

            //Click on the Save Button
            Actions actionUserSave = new Actions(driver);
            actionUserSave.MoveToElement(driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[3]/button[2]"))).Build().Perform();
            IWebElement SaveUsersButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[3]/button[2]"));
            SaveUsersButton.Click();

            //Click on the Roles Tab
            IWebElement RolesTab = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div/div/div/ul/li[2]/a"));
            RolesTab.Click();

            //Click on the + Add role
            IWebElement AddRole = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div/div/div/div/div[2]/div[1]/button/span"));
            AddRole.Click();

            //Select Role in list
            IWebElement SelectRole = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/div/div/div/div/div[3]/div[2]/table/tbody/tr[1]/td[2]/span[1]"));
            SelectRole.Click();

            //Click on the Roles Save button
            Actions actionRolesSave = new Actions(driver);
            actionRolesSave.MoveToElement(driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[3]/button[2]"))).Build().Perform();
            IWebElement RolesSaveBtn = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[3]/button[2]"));
            RolesSaveBtn.Click();

            Assert.Pass();
        }

        [TearDown]
        public void Logout()
        {
            //Logout
            Actions action1 = new Actions(driver);
            action1.MoveToElement(driver.FindElement(By.Id("dropdownMenuUser"))).Build().Perform();
            IWebElement manageProfile = driver.FindElement(By.Id("MenuItem_Account.Logout"));
            manageProfile.Click();
            driver.Quit();
        }
    }
}