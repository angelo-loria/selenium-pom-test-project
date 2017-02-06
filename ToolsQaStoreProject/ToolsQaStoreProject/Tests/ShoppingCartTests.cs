using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolsQaStoreProject.Pages;

namespace ToolsQaStoreProject.Tests
{
    [TestClass]
    public class ShoppingCartTests : TestHelper
    {
        /// <summary>
        /// https://github.com/angelo-loria/selenium-pom-test-project
        /// Selenium/POM framework example using .Net and Selenium. 
        /// Angelo Loria 01/2017
        /// </summary>

        [TestInitialize]
        public void Initialize()
        {
            HelperInitialize();
        }

        [TestCleanup]
        public void CleanUp()
        {
            HelperCleanUp();
        }

        [TestMethod][TestCategory("ShoppingCart")]
        public void AddProductToCart()
        {
            HomePage homePage = new HomePage(driver);
            var productCategoryPage = (ProductCategoryPage)homePage.SelectProductCategory("ipods");
            Assert.IsTrue(productCategoryPage.ProductDisplayed("Magic Mouse"));
            Assert.IsTrue(productCategoryPage.ProductDisplayed("Apple iPod touch 32GB 5th Generation – Black"));
            Assert.IsTrue(productCategoryPage.ProductDisplayed("Apple iPod touch Large"));
            productCategoryPage.ClickAddToCartBtn(2);
            Assert.IsTrue(productCategoryPage.CartNotificationDislpayed("You just added \"Apple iPod touch Large\" to your cart."));
            var checkoutPage = (CheckoutPage)productCategoryPage.SelectGoToCheckout();
            Assert.IsTrue(checkoutPage.SubTotalDisplayed("$10.00"));
            Assert.IsTrue(checkoutPage.ProductListed(0, "Apple iPod touch Large"));
            Assert.IsTrue(checkoutPage.QuantityListed(0, "1"));
            Assert.IsTrue(checkoutPage.ProductPriceDisplayed(0, "$10.00"));
            Assert.IsTrue(checkoutPage.ProductPriceTotalDisplayed(0, "$10.00"));
        }
    }
}
