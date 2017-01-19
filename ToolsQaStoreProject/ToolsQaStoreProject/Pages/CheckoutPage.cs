﻿using System;
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
            return driver.FindElement(subTotal).Text.Contains(price);
        }

        public bool ProductListed(int productIndex, string product)
        {
            var products = 
                driver.FindElements(productRow);
            return products[productIndex].Text.Contains(product);
        }

        public bool QuantityListed(int quantityIndex, string quantity)
        {
            var quantities = 
                driver.FindElements(quantityField);
            return quantities[quantityIndex].GetAttribute("value").Equals(quantity);
        }

        public bool ProductPriceDisplayed(int priceIndex, string price)
        {
            var prices =
                driver.FindElements(priceField);
            return prices[priceIndex].Text.Contains(price);
        }

        public bool ProductPriceTotalDisplayed(int priceTotalIndex, string price)
        {
            var prices =
                driver.FindElements(totalField);
            return prices[priceTotalIndex].Text.Contains(price);
        }
    }
}
