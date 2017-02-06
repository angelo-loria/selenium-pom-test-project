using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;

namespace ToolsQaStoreProject.Tests
{
    /// <summary>
    /// https://github.com/angelo-loria/selenium-pom-test-project
    /// Selenium/POM framework example using .Net and Selenium. 
    /// Angelo Loria 01/2017
    /// </summary>
    public class TestHelper
    {
        public IWebDriver driver;
        public TestContext TestContext { get; set; }

        public void HelperInitialize()
        {
            var browser = TestContext.Properties["browser"].ToString().ToLower();

            switch (browser)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    options.AddArgument("--disable-extensions");
                    driver = new ChromeDriver(options);
                    break;

                case "edge":                 
                    driver = new EdgeDriver();
                    break;
            }

            driver.Navigate().GoToUrl("http://store.demoqa.com/");

            // step to delete cookies in Edge as it does not start new session every test run

            if (browser.Equals("edge"))
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Navigate().Refresh();
            }
        }

        public void HelperCleanUp()
        {
            driver.Quit();
        }
    }
}
