using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationWeek2.SwagLabs.Checkout
{
    public class CheckOut
    {
        IWebDriver driver = null;

        public CheckOut(IWebDriver driver)
        {

            this.driver = driver;
        }

        //Locators
        By fnameLocator = By.Id("first-name");
        By lnameLocator = By.Id("last-name");
        By postalcodeLocator = By.Id("postal-code");
        By continueButtonLocator = By.Id("continue");

        By addedProduct1Price = By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[3]/div[2]/div[2]/div");
        By addedProduct2Price = By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[4]/div[2]/div[2]/div");
        By itemPriceOnPage = By.CssSelector("#checkout_summary_container > div > div.summary_info > div.summary_subtotal_label");
        By totalPriceOnPage = By.CssSelector("#checkout_summary_container > div > div.summary_info > div.summary_total_label");

        public void checkOut(String fname, String lname, String postalcode)
        {


            driver.FindElement(fnameLocator).SendKeys(fname);
            driver.FindElement(lnameLocator).SendKeys(lname);
            driver.FindElement(postalcodeLocator).SendKeys(postalcode);


            //WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //w.Until(ExpectedConditions.ElementExists(By.Id("continue")));

         

            Thread.Sleep(1000);
            driver.FindElement(continueButtonLocator).Click(); //click continue button

            //Prices for added products
            String p1 = driver.FindElement(addedProduct1Price).Text;
            String p2 = driver.FindElement(addedProduct2Price).Text;
           //prices on webpage
            String iTPrice = driver.FindElement(itemPriceOnPage).Text; //itemprice on webpage
            String getTotal = driver.FindElement(totalPriceOnPage).Text; //Total price on webpage
            double taxPrice = 3.20;

            String[] pagePrices = new string[] { iTPrice, getTotal };//array of prices on webpage
            String[] ProductPrices = new string[] { p1, p2 }; //array of prices of added products
            String[] pagePricesSep = new string[pagePrices.Length]; //array for storing prices after applied regular expression
            String[] ProductPricesSep = new string[ProductPrices.Length];


            //removing $ from product prices
            for (int i = 0; i < pagePricesSep.Length; i++)
            {

                pagePricesSep[i] = Regex.Replace(pagePrices[i], @"[^0-9.]+", "");
         
            }
            for (int i = 0; i < ProductPricesSep.Length; i++)
            {

                ProductPricesSep[i] = Regex.Replace(ProductPrices[i], @"[^0-9.]+", "");
         

            }

            double[] pagePriceInDouble = new double[pagePrices.Length];
            Dictionary<String, double> pagedic = new Dictionary<String, double>(); //dict for stroing itemPrice and total price
            

            double[] productPriceInDouble = new double[ProductPrices.Length];
           

            String[] attributes = new String[] { "itemTotal", "getTotalAmount" }; //array for alocating keys in dictionary
 

            //typecasting String to double  
            for (int i = 0; i < pagePriceInDouble.Length; i++)
            {

                pagePriceInDouble[i] = double.Parse(pagePricesSep[i]);
                Console.WriteLine("Page prices in double :" +pagePriceInDouble[i]);
                pagedic.Add(attributes[i], pagePriceInDouble[i]);

            }
            

            for (int i = 0; i < productPriceInDouble.Length; i++)
            {

                productPriceInDouble[i] = double.Parse(ProductPricesSep[i]);
                Console.WriteLine("product prices in double :" + productPriceInDouble[i]);
               
            }

             //Calculation
            // double sumPriceOfProducts = productdic["priceOfProduct1"] + productdic["priceOfProduct2"]; //adding both product prices
            double sumPriceOfProduct = 0.00;

            for (int i = 0; i < productPriceInDouble.Length; i++) {

                sumPriceOfProduct += productPriceInDouble[i];
            
            }
            
            Assert.AreEqual(sumPriceOfProduct, pagedic["itemTotal"]); //Is products Total == itemtotal on webpage?
            Thread.Sleep(1000);
            double calculateTotal = sumPriceOfProduct+ taxPrice; //calculating Total
            Assert.AreEqual(calculateTotal, pagedic["getTotalAmount"]); //Is calculated total == total amount on webpage
            Thread.Sleep(1000);

        }


     

    }
}
