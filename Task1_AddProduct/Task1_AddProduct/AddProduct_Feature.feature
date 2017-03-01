Feature: AddProduct_Feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Adding Product
	Given Login to Unleashed and Navigate to Add Product page
	And Give values to new product and add it
	Then Close the browser
