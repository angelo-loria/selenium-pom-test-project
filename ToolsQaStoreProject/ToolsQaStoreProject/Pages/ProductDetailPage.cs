using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ToolsQaStoreProject.Pages
{
    public class ProductDetailPage : BaseNavigationMenuPage
    {
        public IWebDriver driver;

        public ProductDetailPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
    }
}
