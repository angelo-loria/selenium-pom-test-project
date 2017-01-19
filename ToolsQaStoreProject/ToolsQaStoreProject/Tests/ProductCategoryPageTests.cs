using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolsQaStoreProject.Pages;

namespace ToolsQaStoreProject.Tests
{
    /// <summary>
    /// https://github.com/angelo-loria/selenium-pom-test-project
    /// Selenium/POM framework example using .Net and Selenium. 
    /// Angelo Loria 01/2017
    /// </summary>
    
    [TestClass]
    public class ProductCategoryPageTests : TestHelper
    {
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

        [TestMethod]
        [TestCategory("ProductCategoryPage")]
        public void ProductCategoryPageDisplayed()
        {
            HomePage homePage = new HomePage(driver);
            homePage.SelectNavMenuButton("Product Category");
            var productCategoryPage = new ProductCategoryPage(driver);
            Assert.IsTrue(productCategoryPage.ProductCategoryTitle("Product Category | ONLINE STORE"));
            Assert.IsTrue(productCategoryPage.ProductCategoryHeaderDisplayed("Product Category"));
        }

        [TestMethod]
        [TestCategory("ProductCategoryPage")]
        public void ProductsListed()
        {
            HomePage homePage = new HomePage(driver);
            homePage.SelectNavMenuButton("Product Category");
            var productCategoryPage = new ProductCategoryPage(driver);
            Assert.IsTrue(productCategoryPage.ProductDisplayed("iPhone 5"));
            Assert.IsTrue(productCategoryPage.ProductDisplayed("Magic Mouse"));
            Assert.IsTrue(productCategoryPage.ProductDisplayed("iPod Nano Blue"));
        }

    }
}
