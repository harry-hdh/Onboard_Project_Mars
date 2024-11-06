using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Support.UI;


namespace Testing_Project_Mars_SpecFlow.Utilities
{
    internal class CustomMethods
    {
        public static void Click(IWebDriver driver, By locator)
        {
            CustomWait.WaitToBeClickable(driver, locator, 10);
            try
            {
                driver.FindElement(locator).Click();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void Submit(IWebDriver driver, By locator)
        {
            CustomWait.WaitToBeClickable(driver, locator, 10);
            driver.FindElement(locator).Submit();
        }

        public static void Clear(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Clear();
        }

        public static void ClearEnterText(IWebDriver driver, By locator, string text)
        {
            CustomWait.WaitToBeClickable(driver, locator, 15);
            var txtbox = driver.FindElement(locator);
            try
            {
                txtbox.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            txtbox.Clear();
            //might need another click
            txtbox.SendKeys(text);
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            CustomWait.WaitToBeVisible(driver, locator, 10);
            var txtbox = driver.FindElement(locator);
            try
            {
                txtbox.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            txtbox.SendKeys(text);
        }


        public static void AcceptAlert(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public static string GetText(IWebDriver driver, By locator) 
        {
            CustomWait.WaitToBeVisible(driver, locator, 10);
            IWebElement result = driver.FindElement(locator);

            return result.Text;
        }

        public static string GetNotificationTxt(IWebDriver driver)
        {


            var popupXpath = By.XPath("//div[contains(@class, 'ns-box-inner')]");

            CustomWait.WaitToBeVisible(driver, popupXpath, 15);

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

        public static void SelectDropDown(IWebDriver driver, By locator, string value)
        {
            CustomWait.WaitToBeVisible(driver, locator, 10);
            var dropdown = driver.FindElement(locator);
            var selectElement = new SelectElement(dropdown);

            selectElement.SelectByValue(value);
        }
    }
}
