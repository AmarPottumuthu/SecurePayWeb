Feature: SupportFormFill
	In order to fill in the support form on Contact Us Page
	As a User
	I want to be taken to the Secure Pay Contact Us page by searching for SecurePay on google.com.au

Background: Pre-Condition
	Given I have searched for "SecurePay" on the Google website
	And I have clicked on SecurePay website
@mytag
Scenario: Navigate to ContactUs page
	Given I am on SecurePay website "SecurePay online payment and eCommerce solutions for businesses"
	When I click on Contact Us
	Then the Contact Us page should be displayed with "Contact us" heading
	And Support Form is displayed
	And Support form should accept Data
