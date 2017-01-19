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
            var slides = driver.FindElements(slideSelector);

            slides[0].Click();

            var slideHeaderText =
                driver.WaitForElementDisplayed(slideHeader).Text;

            if (!slideHeaderText.StartsWith(slideProduct))
            {

                slides[1].Click();

                slideHeaderText =
                    driver.WaitForElementDisplayed(slideHeader).Text;

                if (!slideHeaderText.StartsWith(slideProduct))
                {

                    slides[2].Click();

                    slideHeaderText =
                      driver.WaitForElementDisplayed(slideHeader).Text;

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





