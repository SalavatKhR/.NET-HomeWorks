module hw5.Calculator
open hw5.Parser
    
    let Calculate (arg1 : decimal) (operation) (arg2 : decimal) =
        if (operation = Operation.Divide && arg2 = (decimal) 0) then
            Failure "Division by zero"
        else
            let result =
                match operation with
                | Operation.Plus ->   (arg1 + arg2) 
                | Operation.Minus ->   (arg1 - arg2)
                | Operation.Multiply ->   (arg1 * arg2)
                | Operation.Divide  ->   (arg1 / arg2)
            Success result
