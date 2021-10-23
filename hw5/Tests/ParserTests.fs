module ParserTests

open hw5
open Xunit
open Parser


[<Theory>]
[<InlineData("1", "+", "2", 1, "+", 2)>]
[<InlineData("2", "-", "1", 2, "-", 1)>]
[<InlineData("2", "*", "2", 2, "*", 2)>]
[<InlineData("6", "/", "3", 6, "/", 3)>]
let ``TryParserArguments works correctly with correct int values`` (inArg1, inOp, inArg2, expArg1, expOp, expArg2) =
    let arg1, op, arg2 = TryParseArguments [|inArg1; inOp; inArg2|]
    Assert.Equal(Success expArg1, arg1)
    Assert.Equal(Success expOp, op)
    Assert.Equal(Success expArg2, arg2)

[<Theory>]
[<InlineData("1.1", "+", "2.2", 1.1, "+", 2.2)>]
[<InlineData("1.55555556", "-", "5.515151", 1.55555556, "-", 5.515151)>]
[<InlineData("-77.8899", "*", "1.234", -77.8899, "*", 1.234)>]
[<InlineData("0.51111", "/", "1.51111", 0.51111, "/", 1.51111)>]
let ``TryParserArguments works correctly with correct float/double/decimal values`` (inArg1, inOp, inArg2, expArg1, expOp, expArg2) =
    let arg1, op, arg2 = TryParseArguments [|inArg1; inOp; inArg2|]
    Assert.Equal(Success expArg1, arg1)
    Assert.Equal(Success expOp, op)
    Assert.Equal(Success expArg2, arg2)

[<Theory>]
[<InlineData("1.1", "a", "2.2")>]
[<InlineData("3.3", "", "4.4")>]
let ``TryParserArguments gives failure with incorrect operation`` (inArg1, inOp, inArg2) =
    let arg1, op, arg2 = TryParseArguments [|inArg1; inOp; inArg2|]
    Assert.Equal(Failure "Invalid operation.", op)
    
[<Theory>]
[<InlineData("x", "+", "2.2")>]
[<InlineData("", "+", "4.4")>]
let ``TryParserArguments gives failure with incorrect arg1`` (inArg1, inOp, inArg2) =
    let arg1, op, arg2 = TryParseArguments [|inArg1; inOp; inArg2|]
    Assert.Equal(Failure "Invalid value.", arg1)

[<Theory>]
[<InlineData("24", "+", "y")>]
let ``TryParserArguments gives failure with incorrect arg2`` (inArg1, inOp, inArg2) =
    let arg1, op, arg2 = TryParseArguments [|inArg1; inOp; inArg2|]
    Assert.Equal(Failure "Invalid value.", arg2)

[<Theory>]
[<InlineData("x", "+", "y")>]

let ``TryParserArguments gives failure with incorrect args`` (inArg1, inOp, inArg2) =
    let arg1, op, arg2 = TryParseArguments [|inArg1; inOp; inArg2|]
    Assert.Equal(Failure "Invalid value.", arg1) 
    Assert.Equal(Failure "Invalid value.", arg2) 

