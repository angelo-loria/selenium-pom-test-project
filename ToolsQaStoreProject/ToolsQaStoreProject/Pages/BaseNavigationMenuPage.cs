using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ToolsQaStoreProject.Pages
{
    public class BaseNavigationMenuPage : PageElements
    {

        public IWebDriver driver;

        public BaseNavigationMenuPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public bool NavigationMenuDisplayed()
        {
            return driver.FindElement(navigationMenu).Displayed;
        }

        public BaseNavigationMenuPage SelectNavMenuButton(string button)
        {
            var tabs = driver.FindElements(navigationMenuTabs);

            switch (button.ToLower())
            {
                case "home":
                    tabs.FirstOrDefault(x => x.Text.Contains(button)).Click();
                    return new HomePage(driver);                   

                case "product category":
                    tabs.FirstOrDefault(x => x.Text.Contains(button)).Click();
                    return new ProductCategoryPage(driver);                   

            }

            return new BaseNavigationMenuPage(driver);
        }

        public BaseNavigationMenuPage SelectProductCategory(string category)
        {

            switch (category.ToLower())
            {
                case "accesories":
                    break;

                case "imacs":
                    break;

                case "ipads":
                    break;

                case "iphones":
                    break;

                case "ipods":
                    HoverOverProductCategory();
                    var ipods = driver.FindElement(By.Id("menu-item-38"));
                    ipods.Click();
                    return new ProductCategoryPage(driver);

                case "macbooks":
                    break;

            }

            return new BaseNavigationMenuPage(driver);
        }

        private void HoverOverProductCategory()
        {
            var prodCategory = driver.FindElement(productCategoryTab);
            Actions action = new Actions(driver);
            action.MoveToElement(prodCategory);
            action.Perform();
        }



    }
}
