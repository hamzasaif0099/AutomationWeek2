using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationWeek2.Core;
using AutomationWeek2.SwagLabs.Cart;
using AutomationWeek2.SwagLabs.Inventory;
using AutomationWeek2.SwagLabs.Login;
using AutomationWeek2.SwagLabs.Menubar;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AutomationWeek2.AutomationttrainingWebApp.SwagLabs
{
    [TestClass]
    public class CartExecutor
    {

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        String Url = "https://www.saucedemo.com/";


        //Date: 24/1/2022   written by: HAMZA SAIF

        /*          ---------------- DISCRIPTION---------------------
          Validating cart functionality by login -> adding product to cart -> validating added products with those product which are
           selected at the time of adding products -> Logout -> and then login again for validating added products.
        
         */

        [TestMethod]

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\saiffham\source\repos\AutomationWeek2\Data.xml", "addToCart", DataAccessMethod.Sequential)]


        public void cartAddAndValidate()
        {
            #region
            String browser = TestContext.DataRow["browser"].ToString();
            String height = TestContext.DataRow["height"].ToString();
            String width = TestContext.DataRow["width"].ToString();
            String browserType = TestContext.DataRow["browserType"].ToString();
            String deleteCookies = TestContext.DataRow["deleteCookies"].ToString();
            int heightN = Convert.ToInt32(height); //converting height from string to int
            int widthN = Convert.ToInt32(width);    //converting width from string to int

            String username = TestContext.DataRow["username"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String pageText = TestContext.DataRow["pageText"].ToString();
            String itemName = TestContext.DataRow["itemName"].ToString();
            String price = TestContext.DataRow["price"].ToString();
            String quantity = TestContext.DataRow["quantity"].ToString();

            #endregion
            CorePage c1 = new CorePage(browser, Url, heightN, widthN, browserType, deleteCookies); //browser name
                                                                                                   //  SauceLabMethods sauceLab = new SauceLabMethods(c1.driver);
            Inventory i1 = new Inventory(c1.driver);
            Login l1 = new Login(c1.driver);
            Cart cart = new Cart(c1.driver);
            MenuBar menu = new MenuBar(c1.driver);

            l1.loginSauceLab(username, password);
            i1.LoginValidation(pageText);
            i1.addToCartBag();
            i1.openCart();
            cart.cartProductValidation(itemName, price, quantity);
            menu.logoutSauceLab();

            l1.loginSauceLab(username, password);
            i1.LoginValidation(pageText);
            i1.openCart();
            cart.cartProductValidation(itemName, price, quantity);
            c1.driver.Close();


        }


        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\saiffham\source\repos\AutomationWeek2\Data.xml", "dropDown", DataAccessMethod.Sequential)]

        public void dropDown() {
            String browser = TestContext.DataRow["browser"].ToString();
            String height = TestContext.DataRow["height"].ToString();
            String width = TestContext.DataRow["width"].ToString();
            String browserType = TestContext.DataRow["browserType"].ToString();
            String deleteCookies = TestContext.DataRow["deleteCookies"].ToString();

            int heightN = Convert.ToInt32(height); //converting height from string to int
            int widthN = Convert.ToInt32(width);    //converting width from string to int

            String username = TestContext.DataRow["username"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String pageText = TestContext.DataRow["pageText"].ToString();


            CorePage c1 = new CorePage(browser, Url, heightN, widthN, browserType, deleteCookies); //browser name
            Inventory i1 = new Inventory(c1.driver);
            Login l1 = new Login(c1.driver);


            l1.loginSauceLab(username, password);
            i1.LoginValidation(pageText);
            i1.dropDownList();
            c1.driver.Close();
        }



    }

}
  
        