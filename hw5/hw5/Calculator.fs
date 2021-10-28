module hw5.Calculator
open hw5.Parser
    
    let Calculate (arg1 : decimal) (operation) (arg2 : decimal) =
        if (operation = "/" && arg2 = (decimal) 0) then
            Failure "Division by zero"
        else
            let result =
                match operation with
                |  "+" ->   (arg1 + arg2) 
                |  "-" ->   (arg1 - arg2)
                |  "*" ->   (arg1 * arg2)
                | "/"  ->   (arg1 / arg2)
            Success result
