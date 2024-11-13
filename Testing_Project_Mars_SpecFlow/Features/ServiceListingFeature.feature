Feature: ServiceListing

A short summary of the feature
Background:
	Given I log into Mars website successfully with email 'bat_man@yahoo.com' and pass '123qweasd'

@ShareSkill
Scenario Outline: 01) Share new skill with valid data
	When I click Share Skill button to navigate to service listing page 
	Then I enter title as '<Title>', description as '<Description>', select category as '<Category>' & sub-category as '<Sub-category>', tags as '<Tags>', choose service type as One-off service, location typs as Online & skill exchange as '<Skill-Exchange>'
	And I select available days '<Start date>', '<End date>', choose available week day Saturday & Sunday, select available time '<Start1>', '<End1>', '<Start2>', '<End2>'
	Then I click Save button
	Then My new share skill should be created with '<Title>' & '<Description>'
	Examples: 
	| Title         | Description          | Category | Sub-category | Tags | Skill-Exchange | Start date | End date | Start1 | End1 | Start2  | End2  |
	| My livestream | my test description! | 8        | 5            | fps  | chatting       | 01122024   | 01012025 | 1000pm  | 0200am  | 1100pm | 0300am |


@ShareSkill
Scenario Outline: 02) Edit service with valid data
	When I navigate to manage listings tab
	Then I click on edit button of the latest service
	Then I edit title as '<Title>', description as '<Description>', select category as '<Category>' & sub-category as '<Sub-category>', tags as '<Tags>',choose  skill trade as credit skill & credit as '<Credit>'
	And I select available days '<Start date>', '<End date>', choose available day Monday & Tusday, select available time '<Start1>', '<End1>', '<Start2>', '<End2>'
	Then I click Save to update
	Then Share skill should be edited with '<Title>' & '<Description>'
	Examples: 
	| Title   | Description  | Category | Sub-category | Tags   | Credit | Start date | End date | Start1 | End1  | Start2 | End2  |
	| My Logo | I love logo! | 1        | 1            | design | 99     | 02122024   | 01122025 | 0900a  | 0300p | 1000a  | 0400p |


@ShareSkill
Scenario: 03) Delete existing service
	When I navigate to manage listings
	Then I click on delete button and click yes to remove the latest service
	Then I should be able to delete the service


@ShareSkill
Scenario: 04) Share new skill with invalid data
When I click on Share Skill button to navigate to service listing page
Then I try to enter title as '123!' and description as '<>$%' and leave other fields empty
And I try click Save button
Then my skill should not be shared will warning messages  