using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToolsQaStoreProject.Pages
{
    public class ProductCategoryPage : BaseNavigationMenuPage
    {
        public IWebDriver driver;
        private static IReadOnlyCollection<IWebElement> products;

        public ProductCategoryPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        public bool ProductCategoryTitle(string title)
        {
            return driver.WaitForPageTitle(title);
        }


        public bool ProductCategoryHeaderDisplayed(string headerText)
        {
            var headerElement = driver.FindElement(pageHeader);
            return headerElement.Text.Equals(headerText);
        }

        public bool ProductDisplayed(string product)
        {
            products = driver.FindElements(productTitles);
            return products.FirstOrDefault(x => x.Text.StartsWith(product)).Displayed;
        }

        public ProductDetailPage SelectProduct(string product)
        {
            products = driver.FindElements(productTitles);
            products.FirstOrDefault(x => x.Text.StartsWith(product)).Click();
            return new ProductDetailPage(driver);
        }

        public void ClickAddToCartBtn(int buttonIndex)
        {
            var buttons = driver.FindElements(inputBtn);
            buttons[buttonIndex].Click();
        }

        public bool CartNotificationDislpayed(string text)
        {
            Thread.Sleep(2000);
            return driver.FindElement(cartNotification).Text.Contains(text);
        }

        public CheckoutPage SelectGoToCheckout()
        {
            driver.FindElement(goToCheckoutBtn).Click();
            return new CheckoutPage(driver);
        }
    }
}
