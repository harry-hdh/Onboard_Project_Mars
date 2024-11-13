using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_Project_Mars_SpecFlow.Utilities;

namespace Testing_Project_Mars_SpecFlow.Pages
{
    internal class SignOut
    {
        private readonly By signInXpath = By.XPath("//a[contains(text(), 'Sign In')]"); 
        private readonly By signOutXpath = By.XPath("//button[contains(text(), 'Sign Out')]");
        public void LogOut(IWebDriver driver) {
            //CustomWait.WaitToBeClickable(driver, signOutXpath, 10);
            CustomMethods.Click(driver, signOutXpath, "wait_click");
        }

        public string RestriveBtnText(IWebDriver driver) {
            //CustomWait.WaitToBeVisible(driver, signInXpath, 10);
            var textResult = CustomMethods.GetText(driver, signInXpath);
            return textResult;
        }
    }
}
