using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ToolsQaStoreProject.Pages
{
    public class PageElements
    {
        #region HomePage Elements

        public static readonly By slideSelector = By.CssSelector("ul#slide_menu a");
        public static readonly By slideHeader = By.ClassName("product_description");
        #endregion

        #region ProductCategoryPage Elements

        public static readonly By productTitles = By.ClassName("wpsc_product_title");
        public static readonly By inputBtn = By.ClassName("input-button-buy");
        public static readonly By pageHeader = By.ClassName("entry-title");
        public static readonly By cartNotification = By.Id("fancy_notification_content");
        public static readonly By goToCheckoutBtn = By.ClassName("go_to_checkout");

        #endregion

        #region ProductDetailPage Elements

        #endregion

        #region BaseNavigationMenuPage Elements

        public static readonly By navigationMenu = By.Id("main-nav");
        public static readonly By navigationMenuTabs = By.CssSelector("#main-nav ul li a");
        public static readonly By productCategoryTab = By.Id("menu-item-33");
#endregion

        #region CheckoutPage Elements

        public static readonly By subTotal = By.CssSelector(".yourtotal .pricedisplay");
        public static readonly By productRow = By.CssSelector("tr.product_row a");
        public static readonly By quantityField = By.CssSelector("tr.product_row [name='quantity']");
        public static readonly By priceField = By.CssSelector("tr.product_row .pricedisplay");
        public static readonly By totalField = By.CssSelector(".wpsc_product_price .pricedisplay");

        #endregion

    }
}
