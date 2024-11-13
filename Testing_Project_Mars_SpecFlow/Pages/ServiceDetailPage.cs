using Gherkin.Ast;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_Project_Mars_SpecFlow.Utilities;

namespace Testing_Project_Mars_SpecFlow.Pages
{
    internal class ServiceDetailPage
    {
        public By GetByLocation(string location)
        {
            return location switch
            {

                "request btn" => By.XPath("//div[text()='Request']"),

                "withdraw btn" => By.XPath("//div[text()='Withdraw Request']"),

                "yes btn" => By.XPath("//button[text()='Yes']"),

                "manage requests btn" => By.XPath("//div[text()='Manage Requests']"),

                "receive requests btn" => By.XPath("//a[text()='Received Requests']"),

                "sent requests btn" => By.XPath("//a[text()='Sent Requests']"),


                "accept btn" => By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]"),

                "complete btn" => By.XPath("//tr[1]/td[8]/button[text() = 'Completed']"),

                "request message textarea" => By.XPath("//textarea[contains(@placeholder, 'I am interested')]"),

                "status" => By.XPath("//table/tbody/tr[1]/td[5]"),

                _ => throw new NotImplementedException()
            };

        }

        public void ClickSpecific(IWebDriver driver, string location, string type)
        {
            CustomMethods.Click(driver, GetByLocation(location), type);
        }

        public void EnterTxt(IWebDriver driver, string location, string text)
        {
            CustomMethods.ClearEnterText(driver, GetByLocation(location), text);
        }

        public string RetrivePopUpTxt(IWebDriver driver)
        {
            return CustomMethods.GetNotificationTxt(driver);
        }

        public string RetriveDisplayTxt(IWebDriver driver, string location)
        {
            return CustomMethods.GetText(driver, GetByLocation(location));
        }

        public void ClickClosePopUp(IWebDriver driver)
        {
            CustomMethods.ClosePopUp(driver);
        }
    }
}
