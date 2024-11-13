using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using System;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using TechTalk.SpecFlow;
using Testing_Project_Mars_SpecFlow.Pages;


namespace Testing_Project_Mars_SpecFlow.StepDefinitions
{

    [Binding]
    public class ProfileStepDefinitions
    {
        LogIn logInObj = new LogIn();
        ProfilePage profilePageObj = new ProfilePage();

        private readonly IWebDriver driver;
        public ProfileStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I log into Mars website successfully with email '([^']*)' and pass '([^']*)'")]
        public void GivenILogIntoMarsWebsiteSuccessfullyWithEmailAndPass(string email, string pass)
        {
            logInObj.Login(driver, email, pass);
        }

        //add description
        [When(@"I click on pencil icon button to enable description textbox")]
        public void WhenIClickOnPencilIconButtonToEnableDescriptionTextbox()
        {
            profilePageObj.ClickSpecific(driver, "edit description", "wait_click");
        }

        [When(@"I enter random text to the textbox")]
        public void WhenIEnterRandomTextToTheTextbox()
        {
            profilePageObj.EnterTxt(driver, "description textbox", "abc!@#");
        }

        [When(@"I click the save button")]
        public void WhenIClickTheSaveButton()
        {
            profilePageObj.ClickSpecific(driver, "save description", "just_click");
        }

        [Then(@"My desctiption should be saved and display pop up success message")]
        public void ThenMyDesctiptionShouldBeSavedAndDisplayPopUpSuccessMessage()
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("successfully"), "Fail to save description!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "description").Equals("abc!@#"), "Fail to display description");
        }

        //add invalid description
        [When(@"I enable description textbox")]
        public void WhenIEnableDescriptionTextbox()
        {
            profilePageObj.ClickSpecific(driver, "edit description", "wait_click");
        }

        [When(@"I enter a whitespace to the textbox")]
        public void WhenIEnterAWhitespaceToTheTextbox()
        {
            profilePageObj.EnterTxt(driver, "description textbox", " ");
        }


        [Then(@"I click save button")]
        public void ThenIClickSaveButton()
        {
            profilePageObj.ClickSpecific(driver, "save description", "just_click");
        }

        [Then(@"I should not be able to save the description and see warning message")]
        public void ThenIShouldNotBeAbleToSaveTheDescriptionAndSeeWarningMessage()
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("digit or letters"), "Fail to validate inputs!");
        }

        //Add Language
        [When(@"I click on Add New button")]
        public void WhenIClickOnAddNewButton()
        {
            profilePageObj.ClickSpecific(driver, "add new language", "wait_click");
        }

        [When(@"I enter language as '([^']*)' and select level as '([^']*)'")]
        public void WhenIEnterLanguageAsAndSelectLevelAs(string language, string level)
        {
            profilePageObj.EnterTxtLangOrSkill(driver, "language textbox", "level dropdown", language, level);
        }

        [Then(@"I click Add button")]
        public void ThenIClickAddButton()
        {
            profilePageObj.ClickSpecific(driver, "add button", "just_click");
        }

        [Then(@"I should be able to add new language successfully with '([^']*)' & '([^']*)'")]
        public void ThenIShouldBeAbleToAddNewLanguageSuccessfullyWith(string language, string level)
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("added"), "Fail to view success message!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "language").Equals(language), "Fail to add new language!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "language level").Equals(level), "Fail to add new language level!");
        }

        //Edit Language
        [When(@"I click on edit icon button")]
        public void WhenIClickOnEditIconButton()
        {
            profilePageObj.ClickSpecific(driver, "edit language btn", "wait_click");
        }

        [When(@"I update language as '([^']*)' and select level as '([^']*)'")]
        public void WhenIUpdateLanguageAsAndSelectLevelAs(string language, string level)
        {
            profilePageObj.EnterTxtLangOrSkill(driver, "language textbox", "level dropdown", language, level);

        }

        [Then(@"I click Update button")]
        public void ThenIClickUpdateButton()
        {
            profilePageObj.ClickSpecific(driver, "update button", "just_click");
        }

        [Then(@"I should be able to update language successfully with '([^']*)' & '([^']*)'")]
        public void ThenIShouldBeAbleToUpdateLanguageSuccessfullyWith(string language, string level)
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("updated"), "Fail to view success message!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "language").Equals(language), "Fail to edit language!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "language level").Equals(level), "Fail to edit language level!");
        }

        //Delete Language
        [When(@"I click on delete icon button")]
        public void WhenIClickOnDeleteIconButton()
        {
            profilePageObj.ClickSpecific(driver, "remove language btn", "wait_click");
        }

        [Then(@"I should be able to delete language successfully")]
        public void ThenIShouldBeAbleToDeleteLanguageSuccessfully()
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("deleted"), "Fail to delete existing language!");
        }

        //Add Skill
        [When(@"I navigate to skills sub-tab")]
        public void WhenINavigateToSkillsSub_Tab()
        {
            profilePageObj.ClickSpecific(driver, "skills tab", "wait_click");
        }

        [Then(@"I click on Add New button")]
        public void ThenIClickOnAddNewButton()
        {
            profilePageObj.ClickSpecific(driver, "add new skill", "wait_click");
        }

        [Then(@"I enter skill as '([^']*)' and select level as '([^']*)'")]
        public void ThenIEnterSkillAsAndSelectLevelAs(string skill, string level)
        {
            profilePageObj.EnterTxtLangOrSkill(driver, "skill textbox", "level dropdown", skill, level);
        }

        [Then(@"I click Add button to save skill")]
        public void ThenIClickAddButtonToSaveSkill()
        {
            profilePageObj.ClickSpecific(driver, "add button", "just_click");
        }


        [Then(@"I should be able to add new skill successfully with '([^']*)' & '([^']*)'")]
        public void ThenIShouldBeAbleToAddNewSkillSuccessfullyWith(string skill, string level)
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("added"), "Fail to view success message!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "skill").Equals(skill), "Fail to add new skill!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "skill level").Equals(level), "Fail to add new skill level!");
        }

        //Edit skill
        [When(@"I navigate to skills sub-tab to edit skill")]
        public void WhenINavigateToSkillsSub_TabToEditSkill()
        {
            profilePageObj.ClickSpecific(driver, "skills tab", "wait_click");

        }

        [Then(@"I click on edit icon button")]
        public void ThenIClickOnEditIconButton()
        {
            profilePageObj.ClickSpecific(driver, "edit skill btn", "wait_click");
        }

        [Then(@"I update skill as '([^']*)' and select level as '([^']*)'")]
        public void ThenIUpdateSkillAsAndSelectLevelAs(string skill, string level)
        {
            profilePageObj.EnterTxtLangOrSkill(driver, "skill textbox", "level dropdown", skill, level);
        }

        [Then(@"I click Update button to save skill")]
        public void ThenIClickUpdateButtonToSaveSkill()
        {
            profilePageObj.ClickSpecific(driver, "update button", "just_click");
        }


        [Then(@"I should be able to update skill successfully with '([^']*)' & '([^']*)'")]
        public void ThenIShouldBeAbleToUpdateSkillSuccessfullyWith(string skill, string level)
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("updated"), "Fail to view success message!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "skill").Equals(skill), "Fail to edit skill!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "skill level").Equals(level), "Fail to edit skill level!");
        }

        //Delete skill
        [When(@"I navigate to skills sub-tab to delete skill")]
        public void WhenINavigateToSkillsSub_TabToDeleteSkill()
        {
            profilePageObj.ClickSpecific(driver, "skills tab", "wait_click");

        }

        [Then(@"I click on delete icon button to delete skill")]
        public void WhenIClickOnDeleteIconButtonToDeleteSkill()
        {
            profilePageObj.ClickSpecific(driver, "remove skill btn", "wait_click");
        }


        [Then(@"I should be able to delete skill successfully")]
        public void ThenIShouldBeAbleToDeleteSkillSuccessfully()
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("deleted"), "Fail to delete existing skill!");
        }

        //Add education
        [When(@"I navigate to education sub-tab")]
        public void WhenINavigateToEducationSub_Tab()
        {
            profilePageObj.ClickSpecific(driver, "education tab", "wait_click");
        }

        [Then(@"I click on Add New button to add new education")]
        public void ThenIClickOnAddNewButtonToAddNewEducation()
        {
            profilePageObj.ClickSpecific(driver, "add new education", "wait_click");
        }


        [Then(@"I enter college as '([^']*)', select country as '([^']*)', title as '([^']*)', degree '([^']*)', year as '([^']*)'")]
        public void ThenIEnterCollegeAsSelectCountryAsTitleAsDegreeYearAs(string uni, string country, string title, string degree, string year)
        {

            profilePageObj.EnterTxtEducation(driver, "uni textbox", "country dropdown", "title dropdown", "degree textbox", "grad year dropdown", uni, country, title, degree, year);
        }

        [Then(@"I click Add button to save education")]
        public void ThenIClickAddButtonToSaveEducation()
        {
            profilePageObj.ClickSpecific(driver, "add button", "just_click");
        }

        [Then(@"I should be able to add new education successfully with '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenIShouldBeAbleToAddNewEducationSuccessfullyWith(string uni, string country, string title, string degree, string year)
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("added"), "Fail to view success message!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "uni").Equals(uni), "Fail to add new education!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "country").Equals(country), "Fail to add new education!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "title").Equals(title), "Fail to add new education!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "degree").Equals(degree), "Fail to add new education!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "grad year").Equals(year), "Fail to add new education!");

        }

        //Edit education
        [When(@"I navigate to education sub-tab to edit education")]
        public void WhenINavigateToEducationSub_TabToEditEducation()
        {
            profilePageObj.ClickSpecific(driver, "education tab", "wait_click");
        }

        [Then(@"I click on edit icon button to edit education")]
        public void ThenIClickOnEditIconButtonToEditEducation()
        {
            profilePageObj.ClickSpecific(driver, "edit education btn", "wait_click");

        }

        [Then(@"I update college as '([^']*)', select country as '([^']*)', title as '([^']*)', degree '([^']*)', year as '([^']*)'")]
        public void ThenIUpdateCollegeAsSelectCountryAsTitleAsDegreeYearAs(string uni, string country, string title, string degree, string year)
        {
            profilePageObj.EnterTxtEducation(driver, "uni textbox", "country dropdown", "title dropdown", "degree textbox", "grad year dropdown", uni, country, title, degree, year);

        }

        [Then(@"I click Update button to update education")]
        public void ThenIClickUpdateButtonToUpdateEducation()
        {
            profilePageObj.ClickSpecific(driver, "update button", "just_click");

        }

        [Then(@"I should be able to edit new education successfully with '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenIShouldBeAbleToEditNewEducationSuccessfullyWith(string uni, string country, string title, string degree, string year)
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("updated"), "Fail to view success message!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "uni").Equals(uni), "Fail to edit education!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "country").Equals(country), "Fail to add new education!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "title").Equals(title), "Fail to edit education!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "degree").Equals(degree), "Fail to edit education!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "grad year").Equals(year), "Fail to edit education!");
        }

        //Delete education
        [When(@"I navigate to education sub-tab to delete education")]
        public void WhenINavigateToEducationSub_TabToDeleteEducation()
        {
            profilePageObj.ClickSpecific(driver, "education tab", "wait_click");

        }

        [Then(@"I click on delete icon button to remove education")]
        public void WhenIClickOnDeleteIconButtonToRemoveEducation()
        {
            profilePageObj.ClickSpecific(driver, "remove education btn", "wait_click");

        }

        [Then(@"I should be able to delete education successfully")]
        public void ThenIShouldBeAbleToDeleteEducationSuccessfully()
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("removed"), "Fail to delete existing education!");

        }

        //Add Cert
        [When(@"I navigate to Certifications sub-tab")]
        public void WhenINavigateToCertificationsSub_Tab()
        {
            profilePageObj.ClickSpecific(driver, "cert tab", "wait_click");
        }

        [Then(@"I click on Add New button to add certificate")]
        public void ThenIClickOnAddNewButtonToAddCertificate()
        {
            profilePageObj.ClickSpecific(driver, "add new cert", "wait_click");

        }

        [Then(@"I enter award as '([^']*)', from as '([^']*)', year as '([^']*)'")]
        public void ThenIEnterAwardAsFromAsYearAs(string award, string from, string year)
        {
            profilePageObj.EnterTxtCert(driver, "award textbox", "from textbox", "cert year dropdown", award, from, year);
        }

        [Then(@"I click Add button to save certificate")]
        public void ThenIClickAddButtonToSaveCertificate()
        {
            profilePageObj.ClickSpecific(driver, "add button", "just_click");

        }

        [Then(@"I should be able to add new certificate successfully with '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenIShouldBeAbleToAddNewCertificateSuccessfullyWith(string award, string from, string year)
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("added"), "Fail to view success message!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "award").Equals(award), "Fail to add new certification!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "from").Equals(from), "Fail to add new certification!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "cert year").Equals(year), "Fail to add new certification!");
        }

        //Edit cert
        [When(@"I navigate to Certifications sub-tab to edit certification")]
        public void WhenINavigateToCertificationsSub_TabToEditCertification()
        {
            profilePageObj.ClickSpecific(driver, "cert tab", "wait_click");

        }

        [Then(@"I click on edit icon button to update certification")]
        public void ThenIClickOnEditIconButtonToUpdateCertification()
        {
            profilePageObj.ClickSpecific(driver, "edit cert btn", "wait_click");
        }

        [Then(@"I update award as '([^']*)', from as '([^']*)', year as '([^']*)'")]
        public void ThenIUpdateAwardAsFromAsYearAs(string award, string from, string year)
        {
            profilePageObj.EnterTxtCert(driver, "award textbox", "from textbox", "cert year dropdown", award, from, year);

        }

        [Then(@"I click Update button to save certification")]
        public void ThenIClickUpdateButtonToSaveCertification()
        {
            profilePageObj.ClickSpecific(driver, "update button", "just_click");
        }

        [Then(@"I should be able to edit new education successfully with '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenIShouldBeAbleToEditNewEducationSuccessfullyWith(string award, string from, string year)
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("updated"), "Fail to view success message!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "award").Equals(award), "Fail to edit certification!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "from").Equals(from), "Fail to edit certification!");

            Assert.That(profilePageObj.RetriveDisplayTxt(driver, "cert year").Equals(year), "Fail to edit certification!");
        }

        //Delete cert
        [When(@"I navigate to education sub-tab to delete certification")]
        public void WhenINavigateToEducationSub_TabToDeleteCertification()
        {
            profilePageObj.ClickSpecific(driver, "cert tab", "wait_click");
        }

        [Then(@"I click on delete icon button to delete certification")]
        public void ThenIClickOnDeleteIconButtonToDeleteCertification()
        {
            profilePageObj.ClickSpecific(driver, "remove cert btn", "wait_click");

        }


        [Then(@"I should be able to delete certificate successfully")]
        public void ThenIShouldBeAbleToDeleteCertificateSuccessfully()
        {
            Assert.That(profilePageObj.RetrivePopUpTxt(driver).Contains("deleted"), "Fail to delete existing certification!");

        }
    }
}
