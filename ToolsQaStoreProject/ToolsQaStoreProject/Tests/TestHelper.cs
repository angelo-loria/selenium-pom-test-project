using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
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

        public void HelperInitialize()
        {
            var browser = ConfigurationManager.AppSettings["browser"];

            switch (browser.ToLower())
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    options.AddArgument("--disable-extensions");
                    driver = new ChromeDriver(options);
                    break;

                case "firefox":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
            }

            Thread.Sleep(500);
            driver.Navigate().GoToUrl("http://store.demoqa.com/");
        }

        public void HelperCleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
