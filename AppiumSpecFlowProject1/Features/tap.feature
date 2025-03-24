Feature: tap

A short summary of the feature

@Smoke
Scenario: Verify tapping of an element
	Given Launch the application
	When User taps on the views element
	Then User is navigated to views page

@Smoke
Scenario: Verify Checkboxes and radio buttons
	Given Launch the application
	When User taps on the views element
	And User taps on the radio group element
	Then User clicks on the radio button