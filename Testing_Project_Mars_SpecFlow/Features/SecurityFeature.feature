﻿Feature: Security


@Login
Scenario: 01) Log in with invalid email & password
	When I log into Project Mars website with email 'testing@gmail.com' & password as '123qwe'
	Then I should not be able to log in and warning message displayed

@Login
Scenario: 02) Log in with valid email & password
	When I log into Project Mars website with existing account with email 'testing111@gmail.com' & password as '123QWEasd!@#'
	Then I should be able to log in and I should see my name displayed

@LogOut
Scenario: 03) After LogIn user should be able to log out
	When I log into Project Mars website with exist account with email 'testing111@gmail.com' & password '123QWEasd!@#'
	Then I click Sign out button
	Then I should be able to sign out successfully!

@Join
Scenario Outline: 4) Sing Up with invalid password and without agreement untick
	When I am trying to enter firstname as '<Firstname>' lastname as '<Lastname>' email as '<Email>' & invalid password '<Pass>' without agree box ticked
	Then I click Join button to sign up
	Then I shoundn't be able to sign up
	Examples:
		| Firstname | Lastname | Email             | Pass |
		| Iron      | man      | iron_man@gmai.com | 123  |

@Join
Scenario Outline: 5) Sing Up with valid password and with agreement tick
	When I am trying to enter firstname as '<Firstname>' lastname as '<Lastname>' email as '<Email>' & invalid password '<Pass>'
	And I tick the agree box
	Then I click Join to sign up
	Then I shound be able to sign up
	Examples:
		| Firstname | Lastname | Email             | Pass		|
		| Iron      | man      | iron_man@gmai.com | 123qweasd  |
