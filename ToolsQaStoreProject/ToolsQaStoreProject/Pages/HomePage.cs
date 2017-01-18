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
    public class HomePage : BaseNavigationMenuPage
    {
        public IWebDriver driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public bool HomePageTitle(string title)
        {
            return driver.WaitForPageTitle(title);
        }

        public bool CarouselSlideDisplayed(string slideProduct)
        {
            return LoopThroughSlides(slideProduct);
        }

        private bool LoopThroughSlides(string slideProduct)
        {
            var slideButtons = driver.FindElements(By.CssSelector("ul#slide_menu a"));

            slideButtons[0].Click();
            Thread.Sleep(1000);

            var slideHeaderText =
                driver.FindElement(By.CssSelector("div.product_description")).Text;

            if (!slideHeaderText.StartsWith(slideProduct))
            {

                slideButtons[1].Click();
                Thread.Sleep(1000);

                slideHeaderText =
                    driver.FindElement(By.CssSelector("div.product_description")).Text;

                if (!slideHeaderText.StartsWith(slideProduct))
                {

                    slideButtons[2].Click();
                    Thread.Sleep(1000);

                    slideHeaderText =
                        driver.FindElement(By.CssSelector("div.product_description")).Text;

                    if (!slideHeaderText.StartsWith(slideProduct))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}





