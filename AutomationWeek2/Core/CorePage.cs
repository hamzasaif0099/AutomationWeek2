using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace AutomationWeek2.Core
{
    public class CorePage
    {
        /*
        public static IWebDriver driver;

        /* public void BrowserInitialization(String browser,String url, int height, int width) {


             if (browser == "chrome")
             {
                 driver = new ChromeDriver();

                 driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                 driver.Url = url;


             }


             else if (browser == "edge") {
                 driver = new EdgeDriver();
                 driver.Manage().Window.Size = new System.Drawing.Size(height,width);
                 driver.Url = url;

             }

         }


        public IWebDriver BrowserInitialization(String browser, String url, int height, int width)
        {
            if (browser == "chrome")
            {
                driver = new ChromeDriver();

                driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                driver.Url = url;


            }
            else if (browser == "edge")
            {
                driver = new EdgeDriver();
                driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                driver.Url = url;

            }

            return driver;
        }
    
    */

       

        public IWebDriver driver;
        //  String deletecookies = "";
        ChromeOptions options = new ChromeOptions();
        EdgeOptions options1 = new EdgeOptions();
        public CorePage(String Browser, String Url, int height, int width, String browserType, String deleteCookies)
        {

            /*


            if (Browser.Equals("Chrome", StringComparison.InvariantCultureIgnoreCase))    
            {
                if (browserType.Equals("Headless",StringComparison.InvariantCultureIgnoreCase))
                {
                 
                  
                    options.AddArgument("--headless");

                    driver = new ChromeDriver(options);

                    if (deleteCookies.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                    {
                        cookiesDelete();
                    }
                    
                     driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                     driver.Url = Url;
                   

                }

                else
                {


                    driver = new ChromeDriver();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    if (deleteCookies.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                    {
                        cookiesDelete();
                    }
                  driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                    driver.Url = Url;

                }


            }

            else if (Browser.Equals("edge", StringComparison.InvariantCultureIgnoreCase))
            {
                if (browserType.Equals("headless", StringComparison.InvariantCultureIgnoreCase))
                {
                   
                    options1.AddArgument("--headless");
                    driver = new EdgeDriver(options1);
                    if (deleteCookies.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                    {
                        cookiesDelete();
                    }
                    driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                    driver.Url = Url;

                }

                else
                {
                    driver = new EdgeDriver();
                   driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    if (deleteCookies.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                    {
                        cookiesDelete();
                    }
                    driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                    driver.Url = Url;
                }
            }
        }
        //20/1/2022 Hamza
        public void cookiesDelete()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

            */
            
                    
            if (browserType.Equals("Headless", StringComparison.InvariantCultureIgnoreCase))
            {
                options.AddArgument("--headless");

                driver = new ChromeDriver(options);
                driver.Url = Url;
            }
             
            else {


                if (Browser.Equals("Chrome", StringComparison.InvariantCultureIgnoreCase))
                {

                    driver = new ChromeDriver();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                   
                    if (deleteCookies.Equals("true", StringComparison.InvariantCultureIgnoreCase)) {
                        cookiesDelete();

                    }
                    driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                    driver.Url = Url;

                }

                else if (Browser.Equals("Edge", StringComparison.InvariantCultureIgnoreCase))
                {
                    driver = new EdgeDriver();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    if (deleteCookies.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                    {
                        cookiesDelete();
                    }
                    
                    driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                    driver.Url = Url;

                }
               
            }
        }
         
        public void cookiesDelete()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
