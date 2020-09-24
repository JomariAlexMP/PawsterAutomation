using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PawsterAutomation
{
    class Program
    {
        // Create a reference for Chrome browser
        IWebDriver driver = new ChromeDriver();
        /*
        string ActualResult;
        string ExpectedResult = "Google"; */

        static void Main(string[] args)
        {

        }

        [SetUp] //only have 1 setup
        public void Initialize()
        {
            // Go to Pawster Page
            driver.Navigate().GoToUrl("http://localhost:3000/home");
            // Make the browser full screen
            driver.Manage().Window.Maximize();
        }

        /*
            driver.FindElement(By.XPath("/html/body/nav/div/div/ul/li[4]/a")).Click();
            driver.FindElement(By.Name("uname")).SendKeys("usernametest");
            driver.FindElement(By.Id("password")).SendKeys("passwordtest");

            driver.FindElement(By.Name("button")).Click();
            Thread.Sleep(3000);

            IWebElement error = driver.FindElement(By.XPath("/html/body/div[6]/div/div/div[1]/div[2]/h5[1]"));
            string ActualErrorMsg = error.Text;
            String ExpectedErrorMsg = "Username or password is incorrect. Please try again!";
            Assert.AreEqual(ActualErrorMsg, ExpectedErrorMsg);
         */

        [Test] //Name: Successful Login
        public void TC01()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div/ul/li[4]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("uname")).SendKeys("testing");
            driver.FindElement(By.Id("password")).SendKeys("Testing1!");
            driver.FindElement(By.Name("button")).Click();
            Thread.Sleep(2000);

            IWebElement profile = driver.FindElement(By.Id("editprofile"));
            string ActualProfile = profile.Text;
            String ExpectedProfile = "Profile";
            Assert.AreEqual(ActualProfile, ExpectedProfile);
            Thread.Sleep(2000);
        }

        [Test] //Name: Failed Login due to Wrong Username
        public void TCO2()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div/ul/li[4]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("uname")).SendKeys("testingg");
            driver.FindElement(By.Id("password")).SendKeys("Testing1!");
            driver.FindElement(By.Name("button")).Click();
            Thread.Sleep(2000);

            IWebElement error = driver.FindElement(By.XPath("/html/body/div[6]/div/div/div[1]/div[2]/h5[1]"));
            string ActualErrorMsg = error.Text;
            String ExpectedErrorMsg = "Username or password is incorrect. Please try again!";
            Assert.AreEqual(ActualErrorMsg, ExpectedErrorMsg);
            Thread.Sleep(3000);
        }

        [Test] //Name: Failed Login due to Wrong Password
        public void TCO3()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div/ul/li[4]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("uname")).SendKeys("testing");
            driver.FindElement(By.Id("password")).SendKeys("Testing11!");
            driver.FindElement(By.Name("button")).Click();
            Thread.Sleep(2000);

            IWebElement error = driver.FindElement(By.XPath("/html/body/div[6]/div/div/div[1]/div[2]/h5[1]"));
            string ActualErrorMsg = error.Text;
            String ExpectedErrorMsg = "Username or password is incorrect. Please try again!";
            Assert.AreEqual(ActualErrorMsg, ExpectedErrorMsg);
            Thread.Sleep(2000);
        }

        [Test] //Name: Failed Login due to Missing Username
        public void TCO4()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div/ul/li[4]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("uname")).SendKeys("");
            driver.FindElement(By.Id("password")).SendKeys("Testing11!");
            driver.FindElement(By.Name("button")).Click();
            Thread.Sleep(2000);

            //IWebElement error = driver.FindElement(By.XPath("/html/body/div[6]/div/div/div[1]/div[2]/h5[1]"));
            string ActualValidationMsg = driver.FindElement(By.Name("uname")).GetAttribute("validationMessage");
            string ExpectedValidationMsg = "Please fill out this field.";
            Assert.AreEqual(ActualValidationMsg, ExpectedValidationMsg);
            Thread.Sleep(2000);
        }

        [Test] //Name: Failed Login due to Missing Password
        public void TCO5()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div/ul/li[4]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("uname")).SendKeys("testing");
            driver.FindElement(By.Id("password")).SendKeys("");
            driver.FindElement(By.Name("button")).Click();
            Thread.Sleep(2000);

            //IWebElement error = driver.FindElement(By.XPath("/html/body/div[6]/div/div/div[1]/div[2]/h5[1]"));
            string ActualValidationMsg = driver.FindElement(By.Id("password")).GetAttribute("validationMessage");
            string ExpectedValidationMsg = "Please fill out this field.";
            Assert.AreEqual(ActualValidationMsg, ExpectedValidationMsg);
            Thread.Sleep(2000);
        }

        [Test] //Name: Successful Sign Up
        public void TCO6()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div/ul/li[4]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div[2]/form/div[2]/a")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("username")).SendKeys("johndoe");
            driver.FindElement(By.Id("password")).SendKeys("Johndoe1!");
            driver.FindElement(By.Id("confirm-password")).SendKeys("Johndoe1!");
            driver.FindElement(By.Id("email-address")).SendKeys("john.doe@gmail.com");
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/form/div[4]/input")).Click();
            Thread.Sleep(2000);

            IWebElement profile = driver.FindElement(By.Id("editprofile"));
            string ActualProfile = profile.Text;
            String ExpectedProfile = "Profile";
            Assert.AreEqual(ActualProfile, ExpectedProfile);
            Thread.Sleep(2000);
        }

        [Test] //Name: Failed Sign Up because of Password Requirements
        public void TCO7()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div/ul/li[4]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div[2]/form/div[2]/a")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("username")).SendKeys("johndoe");
            driver.FindElement(By.Id("password")).SendKeys("12345");
            driver.FindElement(By.Id("confirm-password")).SendKeys("12345");
            driver.FindElement(By.Id("email-address")).SendKeys("john.doe@gmail.com");
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/form/div[4]/input")).Click();
            Thread.Sleep(2000);

            IWebElement invalid = driver.FindElement(By.Id("invalid-password"));
            string ActualInvalidMsg = invalid.Text;
            String ExpectedInvalidMsg = "invalid password";
            Assert.AreEqual(ActualInvalidMsg, ExpectedInvalidMsg);
            Thread.Sleep(2000);
        }

        [Test] //Name: Failed Sign Up because of Invalid Email
        public void TCO8()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div/ul/li[4]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div[2]/form/div[2]/a")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("username")).SendKeys("johndoe");
            driver.FindElement(By.Id("password")).SendKeys("Johndoe1!");
            driver.FindElement(By.Id("confirm-password")).SendKeys("Johndoe1!");
            driver.FindElement(By.Id("email-address")).SendKeys("ohn.doe.com");
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/form/div[4]/input")).Click();
            Thread.Sleep(2000);

            IWebElement invalid = driver.FindElement(By.Id("invalid-email"));
            string ActualInvalidMsg = invalid.Text;
            String ExpectedInvalidMsg = "Email must follow the format: name@site.com";
            Assert.AreEqual(ActualInvalidMsg, ExpectedInvalidMsg);
            Thread.Sleep(2000);
        }

        [Test] //Name: Failed Sign Up because of Different Password Fields
        public void TCO9()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div/ul/li[4]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div[2]/form/div[2]/a")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("username")).SendKeys("johndoe");
            driver.FindElement(By.Id("password")).SendKeys("Johndoe1!");
            driver.FindElement(By.Id("confirm-password")).SendKeys("Johndoe1!!");
            driver.FindElement(By.Id("email-address")).SendKeys("john.doe@gmail.com");
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/form/div[4]/input")).Click();
            Thread.Sleep(2000);

            IWebElement invalid = driver.FindElement(By.Id("invalid-confirm-password"));
            string ActualInvalidMsg = invalid.Text;
            String ExpectedInvalidMsg = "mismatch!";
            Assert.AreEqual(ActualInvalidMsg, ExpectedInvalidMsg);
            Thread.Sleep(2000); //hello testing
        }

        [TearDown] // 1 teardown
        public void CloseTest()
        {
            // close the browser
            driver.Quit();
        }
    }
}
