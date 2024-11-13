using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Testing_Project_Mars_SpecFlow.Pages;

namespace Testing_Project_Mars_SpecFlow.StepDefinitions
{
    [Binding]
    public class SecurityStepDefinitions
    {
        LogIn logInObj = new LogIn();
        SignOut signOutObj = new SignOut();
        Join joinObj = new Join();

        private readonly IWebDriver driver;
        public SecurityStepDefinitions(IWebDriver driver) { this.driver = driver; } 

        //log in
        [When(@"I log into Project Mars website with email '([^']*)' & password as '([^']*)'")]
        public void GivenILogIntoProjectMarsWebsiteWithEmailPasswordAs(string email, string password)
        {
            logInObj.Login(driver, email, password);
        }

        [Then(@"I should not be able to log in and warning message displayed")]
        public void ThenIShouldNotBeAbleToLogInAndWarningMessageDisplayed()
        {
            Assert.That(logInObj.GetWarningMsg(driver).Contains("Confirm"), "Fail to valdidate username & password!");
        }

        [When(@"I log into Project Mars website with existing account with email '([^']*)' & password as '([^']*)'")]
        public void GivenILogIntoProjectMarsWebsiteWithExistingAccountWithEmailPasswordAs(string email, string password)
        {
            logInObj.Login(driver, email, password);

        }

        [Then(@"I should be able to log in and I should see my name displayed")]
        public void ThenIShouldBeAbleToLogInAndIShouldSeeMyNameDisplayed()
        {
            Assert.That(logInObj.RetriveGreet(driver).Contains("hary"), "Fail to log in!");
        }

        //sign out
        [When(@"I log into Project Mars website with exist account with email '([^']*)' & password '([^']*)'")]
        public void GivenILogIntoProjectMarsWebsiteWithExistAccountWithEmailPassword(string email, string password)
        {
            logInObj.Login(driver, email, password);
        }

        [Then(@"I click Sign out button")]
        public void ThenIClickSignOutButton()
        {
            signOutObj.LogOut(driver);
        }

        [Then(@"I should be able to sign out successfully!")]
        public void ThenIShouldBeAbleToSignOutSuccessfully()
        {
            Assert.That(signOutObj.RestriveBtnText(driver).Equals("Sign In"), "Fail to sign out!");
        }

        //sign up
        [When(@"I enter firstname as '([^']*)' lastname as '([^']*)' random email & invalid password '([^']*)' without agree box ticked")]
        public void WhenIEnterFirstnameAsLastnameAsEmailInvalidPasswordWithoutAgreeBoxTicked(string fname, string lname, string pass)
        {
            joinObj.SignUp(driver, fname, lname, pass);

        }

        [Then(@"I click Join button to sign up")]
        public void ThenIClickJoinButtonToSignUp()
        {
            joinObj.ClickJoinBtn(driver);
        }

        [Then(@"I shoundn't be able to sign up")]
        public void ThenIShoundntBeAbleToSignUp()
        {
            Assert.That(joinObj.RetriveWarningMsg(driver).Equals("Password must be at least 6 characters."), "Fail to Validate inputs!");
        }

        [When(@"I am trying to enter firstname as '([^']*)' lastname as '([^']*)' random email & invalid password '([^']*)'")]
        public void WhenIAmTryingToEnterFirstnameAsLastnameAsRandomEmailInvalidPassword(string fname, string lname, string pass)
        {
            joinObj.SignUp(driver, fname, lname, pass);

        }


        [When(@"I tick the agree box")]
        public void WhenITickTheAgreeBox()
        {
            joinObj.TickAgreeBox(driver);
        }

        [Then(@"I click Join to sign up")]
        public void ThenIClickJoinToSignUp()
        {
            joinObj.ClickJoinBtn(driver);
        }


        [Then(@"I shound be able to sign up")]
        public void ThenIShoundBeAbleToSignUp()
        {
            Assert.That(joinObj.GetSuccessMsg(driver).Contains("successful"), "Fail to sign up!");
        }


    }
}
