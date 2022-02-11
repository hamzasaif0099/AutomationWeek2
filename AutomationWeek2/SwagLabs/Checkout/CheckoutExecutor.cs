using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationWeek2.Core;
using AutomationWeek2.SwagLabs.Cart;
using AutomationWeek2.SwagLabs.Checkout;
using AutomationWeek2.SwagLabs.Inventory;
using AutomationWeek2.SwagLabs.Login;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationWeek2.AutomationttrainingWebApp.SwagLabs
{
    [TestClass]
    public class CheckoutExecutor
    {


        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        String Url = "https://www.saucedemo.com/";


        public const String csvDatasource = "Microsoft.VisualStudio.TestTools.DataSource.CSV";
        public const string csv = @"C:\Users\saiffham\source\repos\AutomationWeek2\AutomationWeek2\SwagLabs\data2.csv";
        public const String csvTag = "data2#csv";

        public const String xmlDatasource = "Microsoft.VisualStudio.TestTools.DataSource.XML";
        public const string xml = @"C:\Users\saiffham\source\repos\AutomationWeek2\Data.xml";
        public const String xmlTag = "checkout";



        //Date: 25/1/2022   written by: HAMZA SAIF

        /*          ---------------- DISCRIPTION---------------------
           
        Validating calculated amount which user have to pay with the total amount which is showing after checkout. 


        */

        [TestMethod, TestCategory("checkoutNew")]
        [DataSource(xmlDatasource, xml, xmlTag, DataAccessMethod.Sequential)]
        public void checkout()
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
            String fname = TestContext.DataRow["fname"].ToString();
            String lname = TestContext.DataRow["lname"].ToString();
            String postal = TestContext.DataRow["postal"].ToString();
            #endregion
            CorePage c1 = new CorePage(browser, Url, heightN, widthN, browserType, deleteCookies); //browser name
                                                                                                   //SauceLabMethods sauceLab = new SauceLabMethods(c1.driver);
            Login l1 = new Login(c1.driver);
            Inventory i1 = new Inventory(c1.driver);
            Cart cart = new Cart(c1.driver);
            CheckOut checkOut = new CheckOut(c1.driver);

            l1.loginSauceLab(username, password);
            i1.LoginValidation(pageText);
            i1.addToCartBag();
            i1.openCart();
            cart.clickCheckOut();
            checkOut.checkOut(fname, lname, postal);

            c1.driver.Close();
        
        }





    }
}
