# Console based calculator

## Description

You have to implement a console based calculator which can perform binary operations on decimal numbers. Your calculator will use the console as its 
display and the keyboard as its key pad. As the user presses keys on the keyboard, the display should update as per the keys pressed. The specifications
for your implementation are - 

### Specifications 
* The calculator should ignore any keys other than the following keys (excluding commas) - `0`, `1`, `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `.`, `-`, `+`, `x`, `/`, `s`, `c`, `=`
* The calculator should support calculating 4 boolean operations - addition `+`, subtraction `-`, division `/` and multiplication `x`.
* Pressing C should reset the calcuator and display `0`.
* On error the calculator should display `-E-`.
* The calculator should support positive and negative decimal numbers.
* On starting the calculator should display `0`.
* Pressing `s` should toggle the sign (positive or negative) of the number from.
* The calcutor should support case insensitivity for keys `x`, `c` and `s`.


The basic starter code for your solution has been provided along with the wiring of the calcuator to the console. You can add your implementation accordingly. 
Your solution should contain the following - 

1. A clean object oriented implementation of the Calcuator. Create additional classes as required for your solution and object model.
2. Unit tests for testing your implemention.
3. Integration with Travis CI for continous integration.

### Examples

The examples below show how the calculator display will update based on the sequence of key board inputs.

**1.**

Scenario is 10 + 2 = 12. 

| Keys Pressed | Updated Display | Remarks |
| ------------ | --------------- | ------- |
| 1 | 1 | |
| 0 | 10 | |
| + | 10 | |
| 2 | 2 | |
| = | 12 | |


**2.**

Scenario is 10 / 0 = -E- 

| Keys Pressed | Updated Display | Remarks |
| ------------ | --------------- | ------- |
| 1 | 1 | |
| 0 | 10 | |
| / | 10 | |
| 0 | 0 | |
| = | -E- | Calcuator displays error due to divide by zero. |


**3.**

| Keys Pressed | Updated Display | Remarks |
| ------------ | --------------- | ------- |
| 0 | 0 | |
| 0 | 0 | Multiple zeros before a decimal point are ignored. |
| . | 0. | |
| . | 0. | Multiple decimal points are ignored. |
| 0 | 0.0 | | 
| 0 | 0.00 | |
| 1 | 0.001 | |


**4.**

| Keys Pressed | Updated Display | Remarks |
| ------------ | --------------- | ------- |
| 1 | 1 | |
| 2 | 12 | |
| + | 12 | |
| 2 | 2 | |
| S | -2 | Sign is toggled. |
| S | 2 | Sign is toggled. | 
| S | -2 | Sign is toggled.  |
| = | 10 | |

**5.**

| Keys Pressed | Updated Display |
| ------------ | --------------- |
| 1 | 1 |
| + | 1 |
| 2 | 2 |
| + | 3 |
| 3 | 3 |
| + | 6 |
| = | 12 |


**6.**

| Keys Pressed | Updated Display |
| ------------ | --------------- |
| 1 | 1 |
| + | 1 |
| 2 | 2 |
| + | 3 |
| C | 0 |

# Three laws of TDD

When doing the exercise, it is important to stick to the three rules of TDD. For more information click [here][4].

1. You may not write production code until you have written a failing unit test.

2. You may not write more of a unit test than is sufficient to fail, and not compiling is failing.

3. You may not write more production code than is sufficient to pass the currently failing test.

# Have fun!

- https://twitter.com/unclebobmartin
- http://butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata
- https://xunit.net/-
- http://butunclebob.com/ArticleS.UncleBob.TheThreeRulesOfTdd
