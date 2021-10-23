module hw5.Program
open Calculator
open Parser

[<EntryPoint>]
let main args =
    if args.Length < 3 then
                printfn "Insufficient amount of arguments."
                -1
    else
        let calculated = result {
                      let arg1, operation, arg2 = TryParseArguments args
                      let! val1 = arg1
                      let! op = operation
                      let! val2 = arg2
                      let! calculated = Calculate val1 op val2
                      return! calculated
        }
        match calculated with
        | Success result -> printf $"{args.[0]} {args.[1]} {args.[3]} = {result}"
        | Failure error -> printf $"{error}"
        0