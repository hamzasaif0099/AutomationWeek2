using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutomationWeek2.AutoIT;
using AutomationWeek2.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationWeek2.Practice
{

    [TestClass]
    public class gmailTestExecutor
    {
        public TestContext instance;

        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        
        
        }

        String url = "https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin";

      //  String url2 = "https://www.tutorialspoint.com/questions/index.php";

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\saiffham\source\repos\AutomationWeek2\gmailData.xml", "gmail", DataAccessMethod.Sequential)]

        public void gmailExecutor() {

            String browser = TestContext.DataRow["browser"].ToString();
            String broweserType = TestContext.DataRow["browserType"].ToString();
            String sheight = TestContext.DataRow["height"].ToString();
            String swidth = TestContext.DataRow["width"].ToString();
            String deleteCookies = TestContext.DataRow["deleteCookies"].ToString();

            String email = TestContext.DataRow["email"].ToString();
            String pass = TestContext.DataRow["password"].ToString();
            String userEmail = TestContext.DataRow["userEmail"].ToString();
            String subject = TestContext.DataRow["subject"].ToString();
            String emailBody = TestContext.DataRow["emailBody"].ToString();

            int height = Convert.ToInt32(sheight);
            int width = Convert.ToInt32(swidth);    
             CorePage cpObj = new CorePage(browser,url,height,width,broweserType,deleteCookies);

            GmailMethods gm = new GmailMethods(cpObj.driver);
            gm.gmailTest(email,pass,userEmail,subject,emailBody);
          

           cpObj.driver.Close();
            
        }


    }
}
