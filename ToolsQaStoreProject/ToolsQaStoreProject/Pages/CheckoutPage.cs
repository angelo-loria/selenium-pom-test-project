using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ToolsQaStoreProject.Pages
{
    public class CheckoutPage : BaseNavigationMenuPage
    {
        public IWebDriver driver;

        public CheckoutPage (IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public bool SubTotalDisplayed(string price)
        {
            return driver.WaitForElementDisplayed(By.CssSelector(".yourtotal .pricedisplay")).Text.Contains(price);
        }

        public bool ProductListed(int productIndex, string product)
        {
            var products = driver.WaitForElementDisplayed(By.CssSelector($"tr.product_row_{productIndex} a"));
            return products.Text.Contains(product);
        }

        public bool QuantityListed(int quantityIndex, string quantity)
        {
            var quantities = 
                driver.WaitForElementDisplayed(
                    By.CssSelector($"tr.product_row_{quantityIndex} [name='quantity']"));
            return quantities.GetAttribute("value").Equals(quantity);
        }

        public bool ProductPriceDisplayed(int priceIndex, string price)
        {
            var prices =
                driver.WaitForElementDisplayed(
                    By.CssSelector($"tr.product_row_{priceIndex} .pricedisplay"));
            return prices.Text.Contains(price);
        }

        public bool ProductPriceTotalDisplayed(int priceTotalIndex, string price)
        {
            var prices =
                driver.WaitForElementDisplayed(
                    By.CssSelector($".wpsc_product_price_{priceTotalIndex} .pricedisplay"));
            return prices.Text.Contains(price);
        }
    }
}
