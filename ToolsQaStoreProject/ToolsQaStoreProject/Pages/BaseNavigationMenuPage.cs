using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ToolsQaStoreProject.Pages
{
    public class BaseNavigationMenuPage 
    {
        private IWebElement _navigationMenu => driver.WaitForElementDisplayed(By.Id("main-nav"));
        private ReadOnlyCollection<IWebElement> _navigationMenuTabs => driver.WaitForElementsDisplayed(By.CssSelector("#main-nav ul li a"));
        private IWebElement _productCategoryTab => driver.WaitForElementDisplayed(By.Id("menu-item-33"));
        private IWebElement _ipodProductCategory => driver.WaitForElementDisplayed(By.Id("menu-item-38"));
        public IWebDriver driver;

        public BaseNavigationMenuPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public bool NavigationMenuDisplayed()
        {
            return _navigationMenu.Displayed;
        }

        public BaseNavigationMenuPage SelectNavMenuButton(string button)
        {

            switch (button.ToLower())
            {
                case "home":
                    _navigationMenuTabs.FirstOrDefault(x => x.Text.Contains(button)).Click();
                    return new HomePage(driver);                   

                case "product category":
                    _navigationMenuTabs.FirstOrDefault(x => x.Text.Contains(button)).Click();
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
                    _ipodProductCategory.Click();
                    return new ProductCategoryPage(driver);

                case "macbooks":
                    break;

            }

            return new BaseNavigationMenuPage(driver);
        }

        private void HoverOverProductCategory()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(_productCategoryTab).ClickAndHold(_productCategoryTab).Build().Perform();
        }



    }
}
