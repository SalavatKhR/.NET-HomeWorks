using System;
using hw4;

namespace CalculatorCS
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var parseResult = Parser.TryParseArguments(args, out var val1,
                out var operation, out var val2);

            if (parseResult != 0)
            {
                return parseResult;
            }

            var result = Calculator.Calculate(val1, operation, val2);
            Console.WriteLine($"{args[0]} {args[1]} {args[2]} = {result}");

            return 0;
        }
    }
}