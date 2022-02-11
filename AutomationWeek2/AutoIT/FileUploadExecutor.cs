using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutomationWeek2.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationWeek2.AutoIT
{

    [TestClass]
    public class FileUploadExecutor
    {
        public TestContext instance;
        public TestContext TestContext 
        {
            set { instance = value; }
            get { return instance; }
        
        }

        String url = "https://www.filemail.com/share/upload-file";
      
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\saiffham\source\repos\AutomationWeek2\DataFolder\fileData.xml", "file", DataAccessMethod.Sequential)]

        public void uploadfileExecutor() {

            String browser = TestContext.DataRow["browser"].ToString();
            String broweserType = TestContext.DataRow["browserType"].ToString();
            String sheight = TestContext.DataRow["height"].ToString();
            String swidth = TestContext.DataRow["width"].ToString();
            String deleteCookies = TestContext.DataRow["deleteCookies"].ToString();

            int height = Convert.ToInt32(sheight);
            int width = Convert.ToInt32(swidth);   



            CorePage cp = new CorePage(browser, url, height, width, broweserType, deleteCookies);

            FileUpload fp = new FileUpload(cp.driver);
            fp.upload();

            Thread.Sleep(1000);
            cp.driver.Close();  



        }
            
            


    }
}
