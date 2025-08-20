Feature: LeaseCalculation

Scenario Outline: Quote a lease of a equipment
	Given Im in the marketplace
	And I have choose a equipment with the requirements
		| Type        | SubType      | YearStart | YearEnd | MaxKm  | Cylinders |
		| Vrachtwagen | Schuifzeilen | 2018      | 2023    | 300000 | 6         |
	And I have <donwPayment> to use as down payment
	And I want a lease duration to be <duration> months
	When I request the quote of lease of the equipment
	Then I should be redirected to details page of the equipment
Examples: 
	| donwPayment | duration |
	| 55290       | 96       |
	| 15000       | 96       |
	| 55290       | 20       |
