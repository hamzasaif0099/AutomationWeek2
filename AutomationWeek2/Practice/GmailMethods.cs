using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutomationWeek2.Practice
{
    public class GmailMethods
    {


        IWebDriver driver = null;


        public GmailMethods(IWebDriver driver) { 
                
            this.driver = driver;        
        
        }
        #region
        By emailLocator = By.XPath("//input[@id='identifierId']");
        By btnAfterEmail = By.XPath("//button[@jsname='LgbsSe']");
        By passLoc = By.XPath("//input[@aria-label='Enter your password']");
        By btnAfterPass = By.CssSelector("#passwordNext > div > button");
        By composeBtn = By.XPath("//div[@class='T-I T-I-KE L3']");
        By recieverEmailloc = By.ClassName("vO");
        By subjectLoc = By.ClassName("aoT");
        By emailBodyLoc = By.ClassName("Am");
        By sendBtnLoc = By.ClassName("dC");
        By AttachBtnLoc = By.XPath("//div[@class='wG J-Z-I' and @aria-label='Attach files']");
        #endregion //locators
        // private static String fileDownloadpath = @"C:\Users\saiffham\Downloads";

        public void gmailTest(String email, String pass, String userEmail, String subject, String emailBody) {
           

            driver.FindElement(emailLocator).SendKeys(email);  
            driver.FindElement(btnAfterEmail).Click(); //click after email entered
            driver.FindElement(passLoc).SendKeys(pass);
            driver.FindElement(btnAfterPass).Click(); //click after enterPass

            driver.FindElement(composeBtn).Click();

            driver.FindElement(recieverEmailloc).SendKeys(userEmail);
            driver.FindElement(subjectLoc).SendKeys(subject);
            driver.FindElement(emailBodyLoc).SendKeys(emailBody);

            driver.FindElement(AttachBtnLoc).Click(); //Click on attachment button

            //driver.FindElement(sendBtnLoc).Click();  driver.FindElement(By.XPath("/html/body/form/div[3]/div[1]/section[2]/div/div[2]/div[2]/div[4]/div/label[1]")).Click();
            Thread.Sleep(2000);

            //Uploading Text file
            Process.Start(@"C:\Users\saiffham\source\repos\AutomationWeek2\fileUploadScript.exe");


            Thread.Sleep(15000);
            driver.FindElement(sendBtnLoc).Click();//Click on Email Send button

           
            sendEmailVerification(subject,emailBody);

        }

        public void sendEmailVerification(String subject, String emailBody) {


            //Verification of Email subject and body
            driver.FindElement(By.XPath("//*[text()='Sent']")).Click(); //Opening sent email from side menu bar


            Thread.Sleep(1000);
            Process.Start(@"C:\Users\saiffham\source\repos\AutomationWeek2\openMail.exe"); //Email openin

            Assert.AreEqual(subject, "Welcome Message");
            Console.WriteLine("Subject Verififed");
            Assert.AreEqual(emailBody, "Note Pad");
            Console.WriteLine("Email body Verified");

            //Sent file title stored into sendFIleTitle field
            String sentFileTitle = driver.FindElement(By.XPath("//div[@class='a12'] //div[@class='aQA'] //span[@class='aV3 zzV0ie']")).Text;

            Assert.AreEqual(sentFileTitle, "NotesFeb.txt"); //validating actual sent file name with expected file name


            Console.WriteLine("Sent File Title Verified");

            //downloading attachment from mail
            driver.FindElement(By.XPath("//div[@class='aQw'] //div[@class='T-I J-J5-Ji aQv T-I-ax7 L3' and @aria-label='Download attachment NotesFeb.txt']")).Click();

            Thread.Sleep(2000);
            Assert.IsTrue(File.Exists(@"C:\Users\saiffham\Downloads\NotesFeb.txt")); //True if file downloaded from mail
            Console.WriteLine("File exits in downloads");

            
        }


    }
}
