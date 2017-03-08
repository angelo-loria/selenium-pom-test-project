using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToolsQaStoreProject.Pages
{
    public class HomePage : BaseNavigationMenuPage
    {
        private ReadOnlyCollection<IWebElement> _slideSelectorBtns => driver.FindElements(By.CssSelector("ul#slide_menu a"));
        private ReadOnlyCollection<IWebElement> _slideHeaders => driver.FindElements(By.ClassName("product_description"));

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
            int slide = 0;

            _slideSelectorBtns[slide].Click();

            var displayedHeader =
                _slideHeaders.FirstOrDefault(x => x.Displayed).Text;

            while (!displayedHeader.Equals(slideProduct))
            {
                _slideSelectorBtns[slide].Click();
                Thread.Sleep(1000);

                displayedHeader =
                    _slideHeaders.FirstOrDefault(x => x.Displayed).Text;

                if (displayedHeader.StartsWith(slideProduct))
                {
                    return true;
                }

                slide++;

                if (slide > 2)
                {
                    return false;
                }
            }           
            return true;
        }

    }
}





