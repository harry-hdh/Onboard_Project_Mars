Feature: Profile

Testing feature in profile page such as write a short description. Add, edit, delete other personal information
Background:
	Given I log into Mars website successfully with email 'bat_man@yahoo.com' and pass '123qweasd'

@Description
Scenario: 01) Write and save a short description
	When I click on pencil icon button to enable description textbox
	And I enter random text to the textbox
	When I click the save button
	Then My desctiption should be saved and display pop up success message

@Description
Scenario: 02) Write and save description with invalid character
	When I enable description textbox
	And I enter a whitespace to the textbox
	Then I click save button
	Then I should not be able to save the description and see warning message

@Add_Languages
Scenario: 03) Add new language
	When I click on Add New button
	And I enter language as 'Eng' and select level as 'Native/Bilingual' 
	Then I click Add button
	Then I should be able to add new language successfully with 'Eng' & 'Native/Bilingual'
@Edit_Languages
Scenario: 04) Edit existing language
	When I click on edit icon button
	And I update language as 'Vn' and select level as 'Fluent' 
	Then I click Update button
	Then I should be able to update language successfully with 'Vn' & 'Fluent'

@Delete_Languages
Scenario: 05) Delete existing language
	When I click on delete icon button
	Then I should be able to delete language successfully

@Add_Skills
Scenario: 06) Add new skill
	When I navigate to skills sub-tab
	Then I click on Add New button
	And I enter skill as 'Typing' and select level as 'Intermediate' 
	Then I click Add button to save skill
	Then I should be able to add new skill successfully with 'Typing' & 'Intermediate'

@Edit_Skills
Scenario: 07) Edit existing skill
	When I navigate to skills sub-tab to edit skill
	Then I click on edit icon button
	And I update skill as 'Testing' and select level as 'Beginner'
	Then I click Update button to save skill
	Then I should be able to update skill successfully with 'Testing' & 'Beginner'

@Delete_Skills
Scenario: 08) Delete existing skill
	When I navigate to skills sub-tab to delete skill
	Then I click on delete icon button to delete skill
	Then I should be able to delete skill successfully

@Add_Education
Scenario: 09) Add new education
	When I navigate to education sub-tab
	Then I click on Add New button to add new education
	And I enter college as 'GMIT', select country as 'Vietnam', title as 'B.A', degree 'IT', year as '2020'
	Then I click Add button to save education
	Then I should be able to add new education successfully with 'GMIT', 'Vietnam', 'B.A', 'IT', '2020'

@Edit_Education
Scenario: 10) Edit existing education
	When I navigate to education sub-tab to edit education
	Then I click on edit icon button to edit education
	And I update college as 'MIT', select country as 'New Zealand', title as 'BFA', degree 'Networking', year as '2021'
	Then I click Update button to update education
	Then I should be able to edit new education successfully with 'MIT', 'New Zealand', 'BFA', 'Networking', '2021'

@Delete_Education
Scenario: 11) Delete existing education
	When I navigate to education sub-tab to delete education
	Then I click on delete icon button to remove education
	Then I should be able to delete education successfully


@Add_Certifications
Scenario: 12) Add new certificate
	When I navigate to Certifications sub-tab
	Then I click on Add New button to add certificate
	And I enter award as 'testing', from as 'UoA', year as '2020'
	Then I click Add button to save certificate
	Then I should be able to add new certificate successfully with 'testing', 'UoA', '2020'

@Edit_Certifications
Scenario: 13) Edit existing certificate
	When I navigate to Certifications sub-tab to edit certification
	Then I click on edit icon button to update certification
	And I update award as 'TestingCert', from as 'AUT', year as '2021'
	Then I click Update button to save certification
	Then I should be able to edit new education successfully with 'TestingCert', 'AUT', '2021'

@Delete_Certifications
Scenario: 14) Delete existing certificate
	When I navigate to education sub-tab to delete certification
	Then I click on delete icon button to delete certification
	Then I should be able to delete certificate successfully