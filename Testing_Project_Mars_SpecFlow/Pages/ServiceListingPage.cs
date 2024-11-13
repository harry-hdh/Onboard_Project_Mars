using Gherkin.Ast;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V128.Input;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_Project_Mars_SpecFlow.Utilities;

namespace Testing_Project_Mars_SpecFlow.Pages
{
    internal class ServiceListingPage
    {
        //private readonly string filePath1= @"C:\Users\hdh99\OneDrive\Pictures\DREDGE\Screenshots\sample.png";
        public By GetByLocation(string location)
        {
            return location switch
            {
                "share skill btn" => By.XPath("//a[contains(text(), 'Share Skill')]"),

                "save btn" => By.XPath("//input[contains(@value, 'Save')]"),

                "upload input" => By.Id("selectFile"),

                "manage list tab" => By.XPath("//a[contains(text(), 'Manage Listings')]"),

                "edit skill btn" => By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[8]/div/button[2]"),

                "delete skill btn" => By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[8]/div/button[3]"),

                "yes btn" => By.XPath("//button[contains(text(), 'Yes')]"),

                "title txtbox" => By.Name("title"),

                "description txtbox" => By.Name("description"),

                "category dropdown" => By.Name("categoryId"),

                "sub-category dropdown" => By.Name("subcategoryId"),

                "tags inputbox" => By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"),

                "skill-exchange inputbox" => By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"),

                "service-type radiobtn" => By.XPath("//input[@name='serviceType' and @value=1]"),

                "location-type radiobtn" => By.XPath("//input[@name='locationType' and @value=1]"),

                "credit radiobtn" => By.XPath("//input[@name='skillTrades' and @value='false']"),

                "startdate inputbox" => By.Name("startDate"),

                "enddate inputbox" => By.Name("endDate"),

                "sunday checkbox" => By.XPath("//input[@name='Available' and @index=0]"),

                "saturday checkbox" => By.XPath("//input[@name='Available' and @index=6]"),

                "monday checkbox" => By.XPath("//input[@name='Available' and @index=1]"),

                "tuesday checkbox" => By.XPath("//input[@name='Available' and @index=2]"),

                "starttime1 inputbox" => By.XPath("//input[@name='StartTime' and @index=0]"),

                "starttime2 inputbox" => By.XPath("//input[@name='StartTime' and @index=6]"),

                "starttime3 inputbox" => By.XPath("//input[@name='StartTime' and @index=1]"),

                "starttime4 inputbox" => By.XPath("//input[@name='StartTime' and @index=2]"),

                "endtime1 inputbox" => By.XPath("//input[@name='EndTime' and @index=0]"),

                "endtime2 inputbox" => By.XPath("//input[@name='EndTime' and @index=6]"),

                "endtime3 inputbox" => By.XPath("//input[@name='EndTime' and @index=1]"),

                "endtime4 inputbox" => By.XPath("//input[@name='EndTime' and @index=2]"),

                "credit inputbox" => By.Name("charge"),

                "tag element" => By.XPath("//form/div[4]/div[2]/div/div/div/span[@class='ReactTags__tag']"),
                "remove tag btn" => By.XPath("//form/div[4]/div[2]/div/div/div/span/a[@class='ReactTags__remove']"),

                "title" => By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[3]"),

                "description" => By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody[last()]/tr/td[4]"),

                "title warning" => By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[2]/div"),

                "description warning" => By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[2]/div"),

                "category warning" => By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div[2]"),

                "tag warning" => By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div[2]"),

                "skil-exchange warning" => By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div[2]"),

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

        public void EnterServiceDetails(IWebDriver driver, string titleLoc, string descriptionLoc, string categoryLoc, string sub_cateLoc , string tagLoc, string service_typeLoc, string location_typeLoc , string skillExLoc, string titleVal, string descriptionVal, string categoryVal, string sub_cateVal, string tagVal, string skillExVal)
        {
            CustomMethods.ClearEnterText(driver, GetByLocation(titleLoc), titleVal);

            CustomMethods.ClearEnterText(driver, GetByLocation(descriptionLoc), descriptionVal);

            CustomMethods.SelectDropDown(driver, GetByLocation(categoryLoc), categoryVal);

            CustomMethods.SelectDropDown(driver, GetByLocation(sub_cateLoc), sub_cateVal);

            CustomMethods.EnterTextPressEnter(driver, GetByLocation(tagLoc), tagVal);

            CustomMethods.Click(driver, GetByLocation(service_typeLoc),"just_click");

            CustomMethods.Click(driver, GetByLocation(location_typeLoc), "just_click");

            CustomMethods.EnterTextPressEnter(driver, GetByLocation(skillExLoc), skillExVal);

        }

        public void EnterServiceDatetime(IWebDriver driver, string startDateLoc, string endDateLoc, string dayLoc1, string dayLoc2, string startTime1Loc, string endTime1Loc, string startTime2Loc, string endTime2Loc, string startDateVal, string endDateVal, string startTime1Val, string endTime1Val, string startTime2Val, string endTime2Val)
        {
            CustomMethods.ClearEnterText(driver, GetByLocation(startDateLoc), startDateVal);

            CustomMethods.ClearEnterText(driver, GetByLocation(endDateLoc), endDateVal);

            CustomMethods.Click(driver, GetByLocation(dayLoc1), "just_click");

            CustomMethods.Click(driver, GetByLocation(dayLoc2), "just_click");

            CustomMethods.ClearEnterText(driver, GetByLocation(startTime1Loc), startTime1Val);

            CustomMethods.ClearEnterText(driver, GetByLocation(endTime1Loc), endTime1Val);

            CustomMethods.ClearEnterText(driver, GetByLocation(startTime2Loc), startTime2Val);

            CustomMethods.ClearEnterText(driver, GetByLocation(endTime2Loc), endTime2Val);

        }

        public void EditServiceDetails(IWebDriver driver, string titleLoc, string descriptionLoc, string categoryLoc, string sub_cateLoc, string tagLoc, string tradeTypeLoc, string creditLoc, string titleVal, string descVal, string cateVal, string sub_cateVal, string tagVal, string creditVal)
        {
            CustomMethods.ClearEnterText(driver, GetByLocation(titleLoc), titleVal);

            CustomMethods.ClearEnterText(driver, GetByLocation(descriptionLoc), descVal);

            CustomMethods.SelectDropDown(driver, GetByLocation(categoryLoc), cateVal);

            CustomMethods.SelectDropDown(driver, GetByLocation(sub_cateLoc), sub_cateVal);

            CustomMethods.CheckAndRemoveElement(driver, GetByLocation("tag element"), GetByLocation("remove tag btn"));

            CustomMethods.EnterTextPressEnter(driver, GetByLocation(tagLoc), tagVal);

            CustomMethods.Click(driver, GetByLocation(tradeTypeLoc), "just_click");

            CustomMethods.ClearEnterText(driver, GetByLocation(creditLoc), creditVal);

        }

        //public void UploadSanpleWork(IWebDriver driver, string uploadLoc) 
        //{
        //    CustomMethods.UploadFile(driver, GetByLocation(uploadLoc), filePath1);
        //}

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
