using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_Project_Mars_SpecFlow.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace Testing_Project_Mars_SpecFlow.Pages
{
    internal class ProfilePage
    {

        private By GetByLocation(string location) 
        {
            return location switch
            {
                "edit description" => By.XPath("//h3/span/i[contains(@class, 'outline write')]"),

                "save description" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"),

                "edit table" => By.XPath("//td/span/i[contains(@class, 'outline write')]"),

                "add button" => By.XPath("//input[contains(@value,'Add')]"),

                "update button" => By.XPath("//input[contains(@value,'Update')]"),

                "add new language" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"),

                "add new skill" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"),

                "add new cert" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"),

                "add new education" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"),


                "skills tab" => By.XPath("//a[contains(text(), 'Skills')]"),

                "education tab" => By.XPath("//a[contains(text(), 'Education')]"),

                "cert tab" => By.XPath("//a[contains(text(), 'Certifications')]"),

                "edit language btn" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"),

                "remove language btn" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"),

                "edit skill btn" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]"),

                "remove skill btn" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"),

                "edit education btn" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]"),

                "remove education btn" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]"),

                "edit cert btn" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]"),

                "remove cert btn" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]"),



                "description textbox" => By.Name("value"),

                "language textbox" => By.XPath("//input[contains(@placeholder,'Add Language')]"),

                "level dropdown" => By.Name("level"),

                "skill textbox" => By.XPath("//input[contains(@placeholder,'Add Skill')]"),

                "uni textbox" => By.XPath("//input[contains(@placeholder,'University Name')]"),

                "country dropdown" => By.Name("country"),

                "title dropdown" => By.Name("title"),

                "degree textbox" => By.Name("degree"),

                "grad year dropdown" => By.Name("yearOfGraduation"),

                "award textbox" => By.Name("certificationName"),

                "from textbox" => By.Name("certificationFrom"),

                "cert year dropdown" => By.Name("certificationYear"),


                "description" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span"),

                "language" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"),

                "language level" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"),

                "skill" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"),

                "skill level" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"),

                "uni" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"),

                "country" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"),

                "title" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"),

                "degree" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"),

                "grad year" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"),

                "award" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"),

                "from" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"),

                "cert year" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"),


                _ => throw new NotImplementedException()
            };
        }

        public void ClickSpecific(IWebDriver driver, string location) 
        {
            CustomMethods.Click(driver, GetByLocation(location));
        }

        public void EnterTxt(IWebDriver driver, string location, string text) 
        {
            CustomMethods.ClearEnterText(driver, GetByLocation(location), text);
        }

        public void SelectOption(IWebDriver driver, string location, string option )
        {
            CustomMethods.SelectDropDown(driver, GetByLocation(location), option);
        }

        public string RetrivePopUpTxt(IWebDriver driver)
        {
            return CustomMethods.GetNotificationTxt(driver);
        }

        public string RetriveDisplayTxt(IWebDriver driver, string location)
        {
            return CustomMethods.GetText(driver, GetByLocation(location));
        }

        public void EnterTxtLangOrSkill(IWebDriver driver, string txtBoxLocation, string dropDownLocation, string text, string opt)
        {
            CustomMethods.ClearEnterText(driver, GetByLocation(txtBoxLocation), text);

            CustomMethods.SelectDropDown(driver, GetByLocation(dropDownLocation), opt);
        }

        public void EnterTxtEducation(IWebDriver driver, string uniLoc, string countryLoc, string titleLoc, string degreeLoc, string yearLoc, string uniTxt, string countryOpt, string titleOpt, string dregreeTxt, string yearOpt)
        {
            CustomMethods.ClearEnterText(driver, GetByLocation(uniLoc), uniTxt);

            CustomMethods.SelectDropDown(driver, GetByLocation(countryLoc), countryOpt);

            CustomMethods.SelectDropDown(driver, GetByLocation(titleLoc), titleOpt);

            CustomMethods.ClearEnterText(driver, GetByLocation(degreeLoc), dregreeTxt);

            CustomMethods.SelectDropDown(driver, GetByLocation(yearLoc), yearOpt);
        }

        public void EnterTxtCert(IWebDriver driver, string awardLoc, string fromLoc, string yearLoc, string awardTxt, string fromTxt, string yearOpt )
        {
            CustomMethods.ClearEnterText(driver, GetByLocation(awardLoc), awardTxt);

            CustomMethods.ClearEnterText(driver, GetByLocation(fromLoc), fromTxt);

            CustomMethods.SelectDropDown(driver, GetByLocation(yearLoc), yearOpt);

        }

    }
}
