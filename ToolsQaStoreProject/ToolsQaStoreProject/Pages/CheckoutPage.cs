using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ToolsQaStoreProject.Pages
{
    public class CheckoutPage : BaseNavigationMenuPage
    {
        private static By _subTotal = By.CssSelector(".yourtotal .pricedisplay");
        private ReadOnlyCollection<IWebElement> _productRows => driver.WaitForElementsDisplayed(By.CssSelector("tr.product_row a"));
        private ReadOnlyCollection<IWebElement> _quantityFields => driver.WaitForElementsDisplayed(By.CssSelector("tr.product_row [name='quantity']"));

        private ReadOnlyCollection<IWebElement> _priceFields => driver.WaitForElementsDisplayed(By.CssSelector("tr.product_row .pricedisplay"));
        private ReadOnlyCollection<IWebElement> _totalFields => driver.WaitForElementsDisplayed(By.CssSelector(".wpsc_product_price .pricedisplay"));

        public IWebDriver driver;


        public CheckoutPage (IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public bool SubTotalDisplayed(string price)
        {
            return driver.WaitForTextDisplayed(_subTotal, price);
        }

        public bool ProductListed(int productIndex, string product)
        {
            return _productRows[productIndex].Text.Contains(product);
        }

        public bool QuantityListed(int quantityIndex, string quantity)
        {
            return _quantityFields[quantityIndex].GetAttribute("value").Equals(quantity);
        }

        public bool ProductPriceDisplayed(int priceIndex, string price)
        {
            return _priceFields[priceIndex].Text.Contains(price);
        }

        public bool ProductPriceTotalDisplayed(int priceTotalIndex, string price)
        {
            return _totalFields[priceTotalIndex].Text.Contains(price);
        }
    }
}
