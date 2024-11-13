using FluentAssertions.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Testing_Project_Mars_SpecFlow.Pages;

namespace Testing_Project_Mars_SpecFlow.StepDefinitions
{
    [Binding]
    public class ServiceListingStepDefinitions
    {
        LogIn logInObj = new LogIn();
        ServiceListingPage serviceListingObj = new ServiceListingPage();

        private readonly IWebDriver driver;
        public ServiceListingStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Create service
        [When(@"I click Share Skill button to navigate to service listing page")]
        public void WhenIClickShareSkillButtonToNavigateToServiceListingPage()
        {
            serviceListingObj.ClickSpecific(driver, "share skill btn", "wait_click");
        }

        [Then(@"I enter title as '([^']*)', description as '([^']*)', select category as '([^']*)' & sub-category as '([^']*)', tags as '([^']*)', choose service type as One-off service, location typs as Online & skill exchange as '([^']*)'")]
        public void ThenIEnterTitleAsDescriptionAsSelectCategoryAsSub_CategoryAsTagsAsChooseServiceTypeAsOne_OffServiceLocationTypsAsOnlineSkillExchangeAs(string title, string description, string category, string sub_category, string tag, string skillExchange)
        {
            serviceListingObj.EnterServiceDetails(driver, "title txtbox", "description txtbox", "category dropdown", "sub-category dropdown", "tags inputbox", "service-type radiobtn", "location-type radiobtn", "skill-exchange inputbox", title, description, category, sub_category, tag, skillExchange);
        }

        [Then(@"I select available days '([^']*)', '([^']*)', choose available week day Saturday & Sunday, select available time '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenISelectAvailableDaysChooseAvailableWeekDaySaturdaySundaySelectAvailableTime(string startDate, string endDate, string startTime1, string startTime2, string endTime1, string endTime2)
        {
            serviceListingObj.EnterServiceDatetime(driver, "startdate inputbox", "enddate inputbox", "sunday checkbox", "saturday checkbox", "starttime1 inputbox", "endtime1 inputbox", "starttime2 inputbox", "endtime2 inputbox", startDate, endDate, startTime1, startTime2, endTime1, endTime2);
        }

        //[Then(@"I choose file example")]
        //public void ThenIChooseFileExample()
        //{
        //    serviceListingObj.UploadSanpleWork(driver, "upload input");
        //}
        //Upload file got issue

        [Then(@"I click Save button")]
        public void ThenIClickSaveButton()
        {
            serviceListingObj.ClickSpecific(driver, "save btn", "just_click");
        }

        [Then(@"My new share skill should be created with '([^']*)' & '([^']*)'")]
        public void ThenMyNewShareSkillShouldBeCreatedWith(string title, string description)
        {
            Assert.That(serviceListingObj.RetriveDisplayTxt(driver, "title").Equals(title), "Fail to create new service");

            Assert.That(serviceListingObj.RetriveDisplayTxt(driver, "description").Equals(description), "Fail to create new service");
        }

        //Edit service
        [When(@"I navigate to manage listings tab")]
        public void WhenINavigateToManageListingsTab()
        {
            serviceListingObj.ClickSpecific(driver, "manage list tab", "wait_click");
        }

        [Then(@"I click on edit button of the latest service")]
        public void ThenIClickOnEditButtonOfTheLatestService()
        {
            serviceListingObj.ClickSpecific(driver, "edit skill btn", "wait_click");
        }

        [Then(@"I edit title as '([^']*)', description as '([^']*)', select category as '([^']*)' & sub-category as '([^']*)', tags as '([^']*)',choose  skill trade as credit skill & credit as '([^']*)'")]
        public void ThenIEditTitleAsDescriptionAsSelectCategoryAsSub_CategoryAsTagsAsChooseSkillTradeAsCreditSkillCreditAs(string title, string description, string category, string sub_category, string tag, string credit)
        {
            serviceListingObj.EditServiceDetails(driver, "title txtbox", "description txtbox", "category dropdown", "sub-category dropdown", "tags inputbox", "credit radiobtn", "credit inputbox", title, description, category, sub_category, tag, credit);
        }

        [Then(@"I select available days '([^']*)', '([^']*)', choose available day Monday & Tusday, select available time '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenISelectAvailableDaysChooseAvailableDayMondayTusdaySelectAvailableTime(string startDate, string endDate, string starttime1, string endtime1, string starttime2, string endtime2)
        {
            serviceListingObj.EnterServiceDatetime(driver, "startdate inputbox", "enddate inputbox", "monday checkbox", "tuesday checkbox", "starttime3 inputbox", "endtime3 inputbox", "starttime4 inputbox", "endtime4 inputbox", startDate, endDate, starttime1, endtime1, starttime2, endtime2);

        }

        [Then(@"I click Save to update")]
        public void ThenIClickSaveToUpdate()
        {
            serviceListingObj.ClickSpecific(driver, "save btn", "just_click");

        }

        [Then(@"Share skill should be edited with '([^']*)' & '([^']*)'")]
        public void ThenShareSkillShouldBeEditedWith(string title, string description)
        {
            Assert.That(serviceListingObj.RetriveDisplayTxt(driver, "title").Equals(title), "Fail to edit service");

            Assert.That(serviceListingObj.RetriveDisplayTxt(driver, "description").Equals(description), "Fail to edit service");
        }

        //Delete service
        [When(@"I navigate to manage listings")]
        public void WhenINavigateToManageListings()
        {
            serviceListingObj.ClickSpecific(driver, "manage list tab", "wait_click");

        }

        [Then(@"I click on delete button and click yes to remove the latest service")]
        public void ThenIClickOnDeleteButtonAndClickYesToRemoveTheLatestService()
        {
            serviceListingObj.ClickSpecific(driver, "delete skill btn", "wait_click");

            serviceListingObj.ClickSpecific(driver, "yes btn", "wait_click");


        }

        [Then(@"I should be able to delete the service")]
        public void ThenIShouldBeAbleToDeleteTheService()
        {
            Assert.That(serviceListingObj.RetrivePopUpTxt(driver).Contains("deleted"), "Fail to delete existing skill service!");

        }

        //Share Skill validation testing
        [When(@"I click on Share Skill button to navigate to service listing page")]
        public void WhenIClickOnShareSkillButtonToNavigateToServiceListingPage()
        {
            serviceListingObj.ClickSpecific(driver, "share skill btn", "wait_click");
        }

        [Then(@"I try to enter title as '([^']*)' and description as '([^']*)' and leave other fields empty")]
        public void ThenITryToEnterTitleAsAndDescriptionAs(string title, string description)
        {
            serviceListingObj.EnterTxt(driver, "title txtbox", title);

            serviceListingObj.EnterTxt(driver, "description txtbox", description);
        }

        [Then(@"I try click Save button")]
        public void ThenITryClickSaveButton()
        {
            serviceListingObj.ClickSpecific(driver, "save btn", "just_click");

        }

        [Then(@"my skill should not be shared will warning messages")]
        public void ThenMySkillShouldNotBeSharedWillWarningMessages()
        {
            Assert.That(serviceListingObj.RetrivePopUpTxt(driver).Equals("Please complete the form correctly."), "Fail to validate inputs!");

            Assert.That(serviceListingObj.RetriveDisplayTxt(driver, "title warning").Equals("Special characters are not allowed."), "Fail to validate title input!");

            Assert.That(serviceListingObj.RetriveDisplayTxt(driver, "description warning").Equals("First character must be an alphabet character or a number."), "Fail to validate description input!");

            Assert.That(serviceListingObj.RetriveDisplayTxt(driver, "category warning").Contains("required"), "Fail to validate category input!");

            Assert.That(serviceListingObj.RetriveDisplayTxt(driver, "tag warning").Contains("required"), "Fail to validate tag input!");

            Assert.That(serviceListingObj.RetriveDisplayTxt(driver, "skil-exchange warning").Contains("required"), "Fail to validate skil-exchange input!");

        }



    }
}
