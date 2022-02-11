using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationWeek2.SwagLabs.Inventory
{
    public class Inventory
    {


        public Inventory(){
}

        IWebDriver driver = null;

        public Inventory(IWebDriver driver)
        {

            this.driver = driver;
        }


        By titleOnHomePage = By.ClassName("title");
        By addProduct1 = By.CssSelector("#add-to-cart-sauce-labs-backpack");
        By addProduct2 = By.CssSelector("#add-to-cart-sauce-labs-bike-light");

        By openCartButton = By.ClassName("shopping_cart_link");

        public void LoginValidation(String pageText) {


            String verifyText = driver.FindElement(titleOnHomePage).Text;

            Assert.AreEqual(pageText, verifyText); //validating login using Product text on page
      }


        //Product adding to cart
        public void addToCartBag()
        {
            //Adding product into cart 
            driver.FindElement(addProduct1).Click();
            driver.FindElement(addProduct2).Click();

            Thread.Sleep(1000);
       }

        public void openCart()
        {
          driver.FindElement(openCartButton).Click();

        }



        public void dropDownList() { 
        
        IWebElement dropdownlist= driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]/div[2]/span/select"));
            SelectElement element = new SelectElement(dropdownlist);
            element.SelectByIndex(2);


        }


        public void productFilter() {

            //product_sort_container
            String check = driver.FindElement(By.XPath("//span[@class='select_container'] //span[@class='active_option']")).Text;
            Console.WriteLine(check);

            IWebElement filterElement = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]/div[2]/span/select"));

            SelectElement e1 = new SelectElement(filterElement);
            e1.SelectByIndex(1);

            String filterAfterSelect = driver.FindElement(By.XPath("//span[@class='select_container'] //span[@class='active_option']")).Text;

            Console.WriteLine(filterAfterSelect);
           
           // ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("image.png");
            Console.WriteLine("Sucesss");

            try
            {


                Assert.AreEqual(filterAfterSelect, "NAME (Z TO A)");
            }

            catch (Exception ex) {
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("Failure.png");

            }
            
           
        }





    }
}
