using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToolsQaStoreProject
{
    public static class ExtensionMethods
    {

        public static IWebElement WaitForElementDisplayed(this IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.PollingInterval = TimeSpan.FromMilliseconds(5);
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
                return wait.Until(ExpectedConditions.ElementIsVisible(by));

            }
            catch (Exception)
            {
                throw new Exception(by + " not found on page.");
            }
        }

        public static bool WaitForPageTitle(this IWebDriver driver, string title)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.PollingInterval = TimeSpan.FromMilliseconds(10);
                return wait.Until(ExpectedConditions.TitleIs(title));
            }
            catch (Exception)
            {
                throw new Exception(title + " not present.");
            }
        }

    }
}
