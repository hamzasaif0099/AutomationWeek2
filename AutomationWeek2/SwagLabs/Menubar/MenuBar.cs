using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationWeek2.SwagLabs.Menubar
{
    public class MenuBar
    {
        IWebDriver driver = null;

        public MenuBar(IWebDriver driver)
        {

            this.driver = driver;
        }

        By menuBarButton = By.XPath("/html/body/div/div/div/div[1]/div[1]/div[1]/div/div[1]/div");
        By logoutButtonLocator = By.Id("logout_sidebar_link");


        //Date: 24/1/2022   written by: HAMZA SAIF
        public void logoutSauceLab()
        {
            driver.FindElement(menuBarButton).Click();

            Thread.Sleep(1000);

            driver.FindElement(logoutButtonLocator).Click();
            Thread.Sleep(2000);
        }



    }
}
