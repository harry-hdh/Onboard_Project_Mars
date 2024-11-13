using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_Project_Mars_SpecFlow.Utilities;

namespace Testing_Project_Mars_SpecFlow.Pages
{
    internal class HomeSearchPage
    {
        public By GetByLocation(string location)
        {
            return location switch
            {
                "search btn" => By.XPath("//i[@class='search link icon']"),

                "search inputbox" => By.XPath("//input[@placeholder='Search skills']"),

                "service card" => By.XPath("//div//a/p[contains(text(), 'Logo')]"),

                "service card1" => By.XPath("//div//a/p[contains(text(), 'new logo')]"),
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
    }
}
