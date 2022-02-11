using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomationWeek2.SwagLabs.Cart
{
    public class Cart
    {
        IWebDriver driver = null;

        public Cart(IWebDriver driver)
        {

            this.driver = driver;
        }

        //Locators
        By cartLink = By.ClassName("shopping_cart_link");
        By productNameText = By.CssSelector("#item_4_title_link > div");
        By productPrice = By.CssSelector("#cart_contents_container > div > div.cart_list > div.cart_item > div.cart_item_label > div.item_pricebar > div");
        By productQuantityLoc = By.XPath("//*[@id='cart_contents_container']/div/div[1]/div[3]/div[1]");
        By checkoutButton = By.Id("checkout");


        // Edited at: 28/1/2022   Written by: Hamza Saif

        /* 
          Validating added product, product's price, product's quantity with actual product,its price and quantity which user
          added at the time of adding product from inventory
         
         */


        public void cartProductValidation(String itemName, String price, String quantity)
        {

            driver.FindElement(cartLink).Click();

            Thread.Sleep(1000);

            String productName = driver.FindElement(productNameText).Text; //actual productname
            Assert.AreEqual(itemName, productName); //validating product Name

            String ActualPrice = driver.FindElement(productPrice).Text;
            Assert.AreEqual(price, ActualPrice); //validating productPrice

            String productQuantity = driver.FindElement(productQuantityLoc).Text;

            Assert.AreEqual(quantity, productQuantity);
            Thread.Sleep(2000);

        }



        //Date: 27/1/2022   Written by: Hamza SAif
        public void clickCheckOut() {

            driver.FindElement(checkoutButton).Click(); //click checkoutbutton

        }

    }
}
