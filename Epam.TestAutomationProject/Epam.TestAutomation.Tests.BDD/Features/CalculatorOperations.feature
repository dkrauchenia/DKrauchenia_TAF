@Calculator
Feature: Calculator
	As a student
	I want to be able to perform basic arithmetic operations
	In order to be able to automate more complex scenarios

@Sum
@Smoke
Scenario: Calculator - Sum
	Given I provide number 2 into calculator
	And I provide number 3 into calculator
	When I choose Sum operation
	Then Result of calculation should be 5

@Diff
@Smoke
Scenario Outline: Calculator - Diff - Data Driven
	Given I provide number <operand1> into calculator
	And I provide number <operand2> into calculator
	When I choose Diff operation
	Then Result of calculation should be <result>
Examples:
| operand1 | operand2 | result |
| 2        | 1        | 1      |
| 1        | 2        | -1     |
| 5        | 5        | 0      |

@Sum
@Smoke
Scenario: Calculator - Mult
	Given I provide number 2 into calculator
	And I provide number 3 into calculator
	When I choose 'Mult' operation
	Then Result of calculation should be 6

@Sum
@Smoke
Scenario: Calculator - Div
	Given I provide number 2 into calculator
	And I provide number 3 into calculator
	When I choose 'Div' operation
	Then I remember the result of calculation

	Given I provide number 2 into calculator
	And I provide number 3 into calculator
	When I choose 'Mult' operation
	Then I remember the result of calculation

	Then I check that collection of results contains 2 items

