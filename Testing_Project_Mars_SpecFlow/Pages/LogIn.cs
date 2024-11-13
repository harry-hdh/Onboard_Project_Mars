using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Testing_Project_Mars_SpecFlow.Utilities;


namespace Testing_Project_Mars_SpecFlow.Pages
{
    internal class LogIn
    {
        private readonly By greetXpath = By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span");
        public void Login(IWebDriver driver, string email, string password)
        {
            CustomMethods.Click(driver, By.XPath("//a[contains(text(), 'Sign In')]"), "wait_click");

            //CustomMethods.SwitchToPopUp(driver, 0);

            CustomMethods.EnterText(driver, By.Name("email"), email);

            CustomMethods.EnterText(driver, By.Name("password"), password);

            CustomMethods.Click(driver, By.XPath("//button[contains(text(), 'Login')]"), "just_click");
        }

        public string RetriveGreet(IWebDriver driver) 
        {
            //CustomWait.WaitToBeVisible(driver, greetXpath, 10);
            var nameResult = CustomMethods.GetText(driver, greetXpath);
            return nameResult;
        }

        public string GetWarningMsg(IWebDriver driver) { return CustomMethods.GetNotificationTxt(driver); }

    }
}
