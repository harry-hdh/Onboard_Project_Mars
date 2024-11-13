using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Testing_Project_Mars_SpecFlow.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace Testing_Project_Mars_SpecFlow.StepDefinitions
{
    [Binding]
    public class ServiceRequestFeatureStepDefinitions
    {
        LogIn logInObj = new LogIn();
        HomeSearchPage homeSearchObj = new HomeSearchPage();
        ServiceDetailPage serviceDetailObj = new ServiceDetailPage();

        private readonly IWebDriver driver;
        public ServiceRequestFeatureStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Request service
        [Given(@"I log in as '([^']*)' with password as '([^']*)'")]
        public void GivenILogInAsWithPasswordAs(string email, string pass)
        {
            logInObj.Login(driver, email, pass);
        }

        [When(@"I search for service as '([^']*)'")]
        public void WhenISearchForServiceAs(string text)
        {
            homeSearchObj.EnterTxt(driver, "search inputbox", text);

            homeSearchObj.ClickSpecific(driver, "search btn", "just_click");
        }

        [Then(@"I click the service to navigate to service detail page")]
        public void ThenIClickTheServiceToNavigateToServiceDetailPage()
        {
            homeSearchObj.ClickSpecific(driver, "service card1", "wait_click");
        }

        [Then(@"I enter request message '([^']*)'")]
        public void ThenIEnterRequestMessage(string message)
        {
            serviceDetailObj.EnterTxt(driver, "request message textarea", message);
        }

        [Then(@"I click Request button")]
        public void ThenIClickRequestButton()
        {
            serviceDetailObj.ClickSpecific(driver, "request btn", "wait_click");
        }

        [Then(@"I click yes button to send request")]
        public void ThenIClickYesButtonToSendRequest()
        {
            serviceDetailObj.ClickSpecific(driver, "yes btn", "wait_click");
        }

        [Then(@"I should be able to send request successfully")]
        public void ThenIShouldBeAbleToSendRequestSuccessfully()
        {
            Assert.That(serviceDetailObj.RetrivePopUpTxt(driver).Equals("Request sent"), "Fail to send request to service owner!");
        }

        //Accept request
        [Given(@"I log in as '([^']*)' password as '([^']*)'")]
        public void GivenILogInAsPasswordAs(string email, string pass)
        {
            logInObj.Login(driver, email, pass);

        }


        [When(@"I navigate to Received Requests page")]
        public void WhenINavigateToReceivedRequestsPage()
        {
            serviceDetailObj.ClickSpecific(driver, "manage requests btn", "wait_click");

            serviceDetailObj.ClickSpecific(driver, "receive requests btn", "wait_click");

        }

        [Then(@"I click Accept button")]
        public void ThenIClickAcceptButton()
        {
            serviceDetailObj.ClickSpecific(driver, "accept btn", "wait_click");
        }

        [Then(@"I should be able to accept request successfully")]
        public void ThenIShouldBeAbleToAcceptRequestSuccessfully()
        {
            
            Assert.That(serviceDetailObj.RetrivePopUpTxt(driver).Equals("Service has been updated"), "Fail to accept service request!");

            Thread.Sleep(3000);

            Assert.That(serviceDetailObj.RetriveDisplayTxt(driver, "status").Equals("Accepted"), "Fail to accept service request!");
        }

        //Complete request
        [Given(@"I log in as '([^']*)' and password as '([^']*)'")]
        public void GivenILogInAsAndPasswordAs(string email, string pass)
        {
            logInObj.Login(driver, email, pass);

        }


        [When(@"I navigate to Sent Requests page")]
        public void WhenINavigateToSentRequestsPage()
        {
            serviceDetailObj.ClickSpecific(driver, "manage requests btn", "wait_click");

            serviceDetailObj.ClickSpecific(driver, "sent requests btn", "wait_click");
        }

        [Then(@"I'm able to see my request is accepted")]
        public void ThenImAbleToSeeMyRequestIsAccepted()
        {
            Assert.That(serviceDetailObj.RetriveDisplayTxt(driver, "status").Equals("Accepted"), "Faill to accept request!");
        }

        [Then(@"I click Completed button")]
        public void ThenIClickCompletedButton()
        {
            serviceDetailObj.ClickSpecific(driver, "complete btn", "wait_click");
        }

        [Then(@"I should be able to complete request successfully")]
        public void ThenIShouldBeAbleToCompleteRequestSuccessfully()
        {
            Assert.That(serviceDetailObj.RetrivePopUpTxt(driver).Equals("Request has been updated"), "Fail to complete request!");

            Assert.That(serviceDetailObj.RetriveDisplayTxt(driver, "status").Equals("Completed"), "Faill to accept request!");

        }

        //Withdraw request
        [Given(@"I sign in as '([^']*)' with password as '([^']*)'")]
        public void GivenISignInAsWithPasswordAs(string email, string pass)
        {
            logInObj.Login(driver, email, pass);

        }


        [When(@"I try search for service as '([^']*)'")]
        public void WhenITrySearchForServiceAs(string text)
        {
            homeSearchObj.EnterTxt(driver, "search inputbox", text);

            homeSearchObj.ClickSpecific(driver, "search btn", "just_click");
        }

        [Then(@"I select the service to navigate to service detail page")]
        public void ThenISelectTheServiceToNavigateToServiceDetailPage()
        {
            homeSearchObj.ClickSpecific(driver, "service card1", "wait_click");

        }

        [Then(@"I try to enter request message '([^']*)'")]
        public void ThenITryToEnterRequestMessage(string message)
        {
            serviceDetailObj.EnterTxt(driver, "request message textarea", message);
        }

        [Then(@"I click Request button to send request")]
        public void ThenIClickRequestButtonToSendRequest()
        {
            serviceDetailObj.ClickSpecific(driver, "request btn", "wait_click");

            serviceDetailObj.ClickSpecific(driver, "yes btn", "wait_click");

            serviceDetailObj.ClickClosePopUp(driver);
        }

        [Then(@"I click Withdraw button")]
        public void ThenIClickWithdrawButton()
        {
            Thread.Sleep(1500);
            serviceDetailObj.ClickSpecific(driver, "withdraw btn", "wait_click");

        }

        [Then(@"I should be able to withdraw request successfully")]
        public void ThenIShouldBeAbleToWithdrawRequestSuccessfully()
        {
            Assert.That(serviceDetailObj.RetrivePopUpTxt(driver).Equals("Request withdraw"),"Fail to withdraw request");
        }
    }
}
