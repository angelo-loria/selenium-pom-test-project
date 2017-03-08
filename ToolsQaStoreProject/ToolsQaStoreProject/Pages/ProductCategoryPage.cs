using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ReadOnlyCollection<IWebElement> _productTitles
            => driver.WaitForElementsDisplayed(By.ClassName("wpsc_product_title"));

        private ReadOnlyCollection<IWebElement> _inputBtns 
            => driver.WaitForElementsDisplayed(By.ClassName("input-button-buy"));

        private readonly By _pageHeader = By.ClassName("entry-title");
        private readonly By _cartNotification = By.Id("fancy_notification_content");
        private IWebElement _goToCheckoutBtn => driver.WaitForElementDisplayed(By.ClassName("go_to_checkout"));

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
            return driver.WaitForTextDisplayed(_pageHeader, headerText);
        }

        public bool ProductDisplayed(string product)
        {

            return _productTitles.FirstOrDefault(x => x.Text.StartsWith(product)).Displayed;
        }

        public ProductDetailPage SelectProduct(string product)
        {          
            _productTitles.FirstOrDefault(x => x.Text.StartsWith(product)).Click();
            return new ProductDetailPage(driver);
        }

        public void ClickAddToCartBtn(int buttonIndex)
        {
            _inputBtns[buttonIndex].Click();
        }


        public bool CartNotificationDislpayed(string text)
        {
            return driver.WaitForTextDisplayed(_cartNotification, text);
        }

        public CheckoutPage SelectGoToCheckout()
        {
            _goToCheckoutBtn.Click();
            return new CheckoutPage(driver);
        }
    }
}
