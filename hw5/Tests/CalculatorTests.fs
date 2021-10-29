module CalculatorTests
open hw5
open Parser
open Xunit
open Calculator

[<Theory>]
[<InlineData(1, "+", 1, 2)>]
[<InlineData(2, "-", 1, 1)>]
[<InlineData(2, "*", 2, 4)>]
[<InlineData(6, "-", 7, -1)>]
let ``Calculate works correctly with correct int values`` (arg1, op, arg2, expected) =
    let result = Calculate arg1 op arg2
    Assert.Equal(Success expected, result)

[<Theory>]
[<InlineData(1.6, "+", 2.0, 3.6)>]
[<InlineData(3.001, "-", 1.5005, 1.5005)>]
[<InlineData(0.00005, "*", 2, 0.0001)>]
[<InlineData(7.7777, "/", 7.7777, 1)>]
let ``Calculate works correctly with correct float/double/decimal values`` (arg1, op, arg2, expected) =
    let result = Calculate arg1 op arg2
    Assert.Equal(Success expected, result)
    
[<Theory>]
[<InlineData(2.5, "/", 0)>]
let ``Calculate gives failure when division by zero`` (arg1, op, arg2) =
    let result = Calculate arg1 op arg2
    Assert.Equal(Failure "Division by zero", result)