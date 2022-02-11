using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutomationWeek2.AutoIT
{
    public class FileUpload
    {

        public IWebDriver driver = null;

        public FileUpload(IWebDriver driver) { 
        
        this.driver = driver;
        }

        public void upload() {



        //  ((IJavaScriptExecutor)driver).ExecuteScript("scroll(0,400)");


            driver.FindElement(By.XPath("/html/body/form/div[3]/div[1]/section[2]/div/div[2]/div[2]/div[4]/div/label[1]")).Click();
            Thread.Sleep(2000);

           
            Process.Start(@"C:\Users\saiffham\source\repos\AutomationWeek2\fileUploadScript.exe");
            
            Thread.Sleep(2000);

                
        
        }
    }
}
