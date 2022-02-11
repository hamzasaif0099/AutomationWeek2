using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationWeek2.Core;
using AutomationWeek2.SwagLabs.Inventory;
using AutomationWeek2.SwagLabs.Login;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationWeek2.AutomationttrainingWebApp.SwagLabs
{
    [TestClass]
    public class InventoryExecutor
    {

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }
        String Url = "https://www.saucedemo.com/";

        [TestMethod]

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\saiffham\source\repos\AutomationWeek2\Data.xml", "productFilter", DataAccessMethod.Sequential)]

        public void productFilterExecutor() {

            String browser = TestContext.DataRow["browser"].ToString();
            String height = TestContext.DataRow["height"].ToString();
            String width = TestContext.DataRow["width"].ToString();
            String browserType = TestContext.DataRow["browserType"].ToString();
            String deleteCookies = TestContext.DataRow["deleteCookies"].ToString();

            String username = TestContext.DataRow["username"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String pageText = TestContext.DataRow["pageText"].ToString();

            int heightInt = Convert.ToInt32(height);
            int widthInt = Convert.ToInt32(width);  

            CorePage corePageObj = new CorePage(browser,Url, heightInt, widthInt, browserType, deleteCookies);

            Login loginObj = new Login(corePageObj.driver);
            loginObj.loginSauceLab(username,password);
            Inventory inventoryObj = new Inventory(corePageObj.driver);
          inventoryObj.LoginValidation(pageText);
            inventoryObj.productFilter();

        }
                




    }
}
