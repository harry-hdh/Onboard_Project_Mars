using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;


namespace Testing_Project_Mars_SpecFlow.Utilities
{
    internal class CustomMethods
    {
        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void Submit(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Submit();
        }

        public static void Clear(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Clear();
        }

        public static void ClearEnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            //driver.FindElement(locator).Click();
            driver.FindElement(locator).SendKeys(text);
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).SendKeys(text);
        }


        public static void AcceptAlert(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public static string GetText(IWebDriver driver, By locator) 
        {
            IWebElement result = driver.FindElement(locator);

            return result.Text;


        }

        public static string GetNotificationTxt(IWebDriver driver)
        {
            var popupXpath = By.XPath("//div[contains(@class, 'ns-box-inner')]");

            CustomWait.WaitToBeVisible(driver, popupXpath, 10);

            IWebElement result = driver.FindElement(popupXpath);

            return result.Text;
        }

        public static void SwitchToPopUp(IWebDriver driver, int frameNumber)
        {
            driver.SwitchTo().Frame(frameNumber);
        }

        public static void SwitchBackToDefault(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
