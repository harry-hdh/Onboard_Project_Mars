Feature: ServiceRequestFeature

Testing search, request, accpect, complete and withdraw request for Project Mars website

@Request
Scenario: 01) Find service and send request
	Given I log in as 'testing111@gmail.com' with password as '123qweasd'
	When I search for service as 'new logo'
	Then I click the service to navigate to service detail page
	Then I enter request message 'hi test!'
	And I click Request button 
	And I click yes button to send request
	Then I should be able to send request successfully
#Request sent


@Accept
Scenario: 02) Accept service request
	Given I log in as 'bat_man@yahoo.com' password as '123qweasd'
	When I navigate to Received Requests page
	Then I click Accept button
	Then I should be able to accept request successfully


@Complete
Scenario: 03) Complete service request
Given I log in as 'testing111@gmail.com' and password as '123qweasd'
	When I navigate to Sent Requests page
	Then I'm able to see my request is accepted
	Then I click Completed button
	Then I should be able to complete request successfully


@Withdraw
Scenario: 04) Withdraw service request
Given I sign in as 'iron_man@gmai.com' with password as '123qweasd'
	When I try search for service as 'new logo'
	Then I select the service to navigate to service detail page
	Then I try to enter request message 'test!'
	And I click Request button to send request
	Then I click Withdraw button
	Then I should be able to withdraw request successfully
