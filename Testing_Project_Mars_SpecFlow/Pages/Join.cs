using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Testing_Project_Mars_SpecFlow.Utilities;

namespace Testing_Project_Mars_SpecFlow.Pages
{
    internal class Join
    {
        public void SignUp(IWebDriver driver, string firstname, string lastname, string email, string password) 
        {
            CustomMethods.Click(driver, By.XPath("//button[contains(text(), 'Join')]"));

            CustomMethods.EnterText(driver, By.Name("firstName"), firstname);

            CustomMethods.EnterText(driver, By.Name("lastName"), lastname);

            CustomMethods.EnterText(driver, By.Name("email"), email);

            CustomMethods.EnterText(driver, By.Name("password"), password);

            CustomMethods.EnterText(driver, By.Name("confirmPassword"), password);

        }

        public void TickAgreeBox(IWebDriver driver) 
        {
            CustomMethods.Click(driver, By.Name("terms"));
        }

        public void ClickJoinBtn(IWebDriver driver)
        {
            CustomMethods.Click(driver, By.Id("submit-btn"));
        }

        public string RetriveWarningMsg(IWebDriver driver) 
        {
            var result = CustomMethods.GetText(driver, By.XPath("//div[contains(@class, 'ui basic red') and contains(text(), 'Password')]"));
            return result;
        }

        public string GetSuccessMsg(IWebDriver driver) { return CustomMethods.GetNotificationTxt(driver); }

    }
}
