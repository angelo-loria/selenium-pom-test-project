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

        private static readonly By productTitles = By.CssSelector("div.default_product_display div h2 a");
        private static IReadOnlyCollection<IWebElement> products;
        private static readonly By inputBtn = By.ClassName("input-button-buy");



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
            var headerElement = driver.FindElement(By.CssSelector("header.page-header h1"));
            return headerElement.Text.Equals(headerText);
        }

        public bool ProductDisplayed(string product)
        {
            products = driver.WaitForElementsDisplayed(productTitles);
            return products.FirstOrDefault(x => x.Text.StartsWith(product)).Displayed;
        }

        public ProductDetailPage SelectProduct(string product)
        {
            products = driver.WaitForElementsDisplayed(productTitles);
            products.FirstOrDefault(x => x.Text.StartsWith(product)).Click();
            return new ProductDetailPage(driver);
        }

        public void ClickAddToCartBtn(int buttonIndex)
        {
            var buttons = driver.FindElements(inputBtn);
            buttons[buttonIndex].Click();;
        }

        public bool CartNotificationDislpayed(string text)
        {
            Thread.Sleep(2000);
            var notification = driver.FindElement(By.Id("fancy_notification_content"));
            return notification.Text.Contains(text);
        }

        public CheckoutPage SelectGoToCheckout()
        {
            driver.FindElement(By.ClassName("go_to_checkout")).Click();
            return new CheckoutPage(driver);
        }
    }
}
