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
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.PollingInterval = TimeSpan.FromMilliseconds(10);
                return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }


        public static ReadOnlyCollection<IWebElement> WaitForElementsDisplayed(this IWebDriver driver, By by)
        {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.PollingInterval = TimeSpan.FromMilliseconds(10);
                return wait.Until(drv => drv.FindElements(by).Count > 0 ? drv.FindElements(by) : null);
        }


        public static bool WaitForPageTitle(this IWebDriver driver, string title)
        {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return wait.Until(ExpectedConditions.TitleIs(title));
        }

        public static bool WaitForTextDisplayed(this IWebDriver driver, By by, string text)
        {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return wait.Until(ExpectedConditions.TextToBePresentInElement(driver.WaitForElementDisplayed(by), text));
        }

    }
}
