using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace hw11.ExpressionTree
{
    public class Parser
    {
        private static readonly Dictionary<string, int> _operatorPrecedance = new()
        {
            {"(", 1},
            {"-", 2},
            {"+", 2},
            {"*", 3},
            {"/", 3}
        };
        
        private static readonly Regex _inputSplit = new ("(?<=[-+*/\\(\\)])|(?=[-+*/\\(\\)])");
        private static readonly Regex _operand = new ("[0-9]+");

        public static string ToPostfix(string expression)
        {
            var operators = new Stack<string>();
            var postfix = new Stack<string>();
            var replacedExpr = expression
                .Replace("plus", "+")
                .Replace("subtract", "-")
                .Replace("minus", "-")
                .Replace("multiply", "*")
                .Replace("divide", "/");
            foreach (var i in string.Join(" ", _inputSplit.Split(replacedExpr)).Split(" "))
            {
                if (i == "(")
                {
                    operators.Push(i);
                }
                else if (_operand.IsMatch(i))
                {
                    postfix.Push(i);
                }
                else if (i == ")")
                {
                    while (operators.Peek() != "(")
                    {
                        var op = operators.Pop();
                        var first = postfix.Pop();
                        var second = postfix.Pop();
                        postfix.Push(second + " " + first + " " + op);
                    }

                    operators.Pop();
                }
                else
                {
                    while (operators.Count > 0 && operators.Peek() != "(" &&
                           _operatorPrecedance[i] <= _operatorPrecedance[operators.Peek()])
                    {
                        var op = operators.Pop();
                        var first = postfix.Pop();
                        var second = postfix.Pop();
                        postfix.Push(second + " " + first + " " + op);
                    }

                    operators.Push(i);
                }
            }

            while (operators.Count > 0)
            {
                var op = operators.Pop();
                var first = postfix.Pop();
                var second = postfix.Pop();
                postfix.Push(second + " " + first + " " + op);
            }

            return postfix.Pop();
        }
    }
}