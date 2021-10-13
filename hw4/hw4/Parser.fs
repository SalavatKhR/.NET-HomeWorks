namespace hw4

module Parser =

    let isOperationSupported (operation : string) =
        match operation with
            | "+" | "-" | "*" | "/" -> true
            | _ -> false
    let TryParseArguments (args : string[]) (arg1 : outref<int>) (operation : outref<string> ) (arg2 : outref<int>) =
        let isVal1Int = System.Int32.TryParse(args.[0], &arg1)
        let isVal2Int = System.Int32.TryParse(args.[2], &arg2)
        operation <- args.[1]
        if not (isVal1Int && isVal2Int) then
             printfn $"{args.[0]} {args.[1]} {args.[2]} invalid arguments."
             1
        elif not (isOperationSupported args.[1]) then
             printf $"{args.[0]} {args.[1]} {args.[2]} invalid arguments."
             2
        elif args.[1] = "/" && args.[2] = "0" then
             printf $"{args.[0]} {args.[1]} {args.[2]} divide bu zero."
             3
        else 0    

