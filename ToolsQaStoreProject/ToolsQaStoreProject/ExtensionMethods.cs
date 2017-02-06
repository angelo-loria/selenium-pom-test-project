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
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.PollingInterval = TimeSpan.FromMilliseconds(10);
                return wait.Until(ExpectedConditions.ElementToBeClickable(by));

            }
            catch (Exception)
            {
                throw new Exception(by + " not found on page.");
            }
        }


        public static ReadOnlyCollection<IWebElement> WaitForElementsDisplayed(this IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.PollingInterval = TimeSpan.FromMilliseconds(10);
                return wait.Until(drv => drv.FindElements(by).Count > 0 ? drv.FindElements(by) : null);

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
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return wait.Until(ExpectedConditions.TitleIs(title));
            }
            catch (Exception)
            {
                throw new Exception(title + " not present.");
            }
        }

        public static bool WaitForTextDisplayed(this IWebDriver driver, By by, string text)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return wait.Until(ExpectedConditions.TextToBePresentInElement(driver.WaitForElementDisplayed(by), text));
            }
            catch (Exception)
            {

                throw new Exception(text + " not present.");

            }
        }

    }
}
