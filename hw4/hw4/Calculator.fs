namespace hw4

module Calculator = 
    let Calculate arg1 operation arg2 =
        match operation with
        | "+" -> arg1 + arg2
        | "-" -> arg1 - arg2 
        | "*" -> arg1 * arg2 
        | "/" -> arg1 / arg2

