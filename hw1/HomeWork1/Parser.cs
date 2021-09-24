using System;
using System.Linq;

namespace Homework1
{
    public static class Parser
    {
        private static readonly string[] SupportedOperations = {
            "+",
            "-",
            "*",
            "/"
        };
        
        public static int TryParseArguments(string[] args, out double val1, out string operation, out double val2)
        {
            var isVal1Int = double.TryParse(args[0], out val1);
            operation = args[1];
            var isVal2Int = double.TryParse(args[2], out val2);

            if (!isVal1Int || !isVal2Int)
            {
                Console.WriteLine($"{args[0]}{args[1]}{args[2]} is not a valid calculation syntax");
                return 1;
            }

            if (!SupportedOperations.Contains(operation))
            {
                Console.WriteLine(
                    $"{args[0]}{args[1]}{args[2]} is not a valid calculation syntax. "
                    + $"Supported operations are "
                    + $"{SupportedOperations.Aggregate((c, n) => $"{c} {n}")}");
                return 2;
            }
            
            if (args[1] == "/" && args[2] == "0")
            {
                Console.WriteLine($"{args[0]}{args[1]}{args[2]} - divide by zero");
                return 3;
            }

            return 0;
        }
    }
}