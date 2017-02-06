using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolsQaStoreProject.Pages;

namespace ToolsQaStoreProject.Tests
 
{
    [TestClass]
    public class HomePageTests : TestHelper
    {
        /// <summary>
        /// https://github.com/angelo-loria/selenium-pom-test-project
        /// Selenium/POM framework example using .Net and Selenium. 
        /// Please select browser using the Test menu -> Test Settings -> Chrome.runsettings || Edge.runsettings
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

        [TestMethod]
        [TestCategory("HomePage")]
        public void HomePageDisplayed()
        {
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.HomePageTitle("ONLINE STORE | Toolsqa Dummy Test site"));
            Assert.IsTrue(homePage.NavigationMenuDisplayed());
        }

        [TestMethod]
        [TestCategory("HomePage")]

        public void CarouselSlidesDisplayed()
        {
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.CarouselSlideDisplayed("iPod Nano Blue"));
            Assert.IsTrue(homePage.CarouselSlideDisplayed("iPhone 5"));
            Assert.IsTrue(homePage.CarouselSlideDisplayed("Magic Mouse"));
        }

    }
}
