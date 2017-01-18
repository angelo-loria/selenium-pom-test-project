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
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
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
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                return wait.Until(ExpectedConditions.TitleIs(title));
            }
            catch (Exception)
            {
                throw new Exception(title + " not present.");
            }
        }

        public static ReadOnlyCollection<IWebElement> WaitForElementsDisplayed(this IWebDriver driver, By by)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                return wait.Until(drv => drv.FindElements(by).Count > 0 ? drv.FindElements(by) : null);
            }
            catch (Exception)
            {
                throw new Exception(by + " not found on the page");
            }
        }

    }
}
