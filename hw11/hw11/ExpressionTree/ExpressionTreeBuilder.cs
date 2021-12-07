using System.Collections.Generic;
using System.Linq.Expressions;

namespace hw11.ExpressionTree
{
    public class ExpressionTreeBuilder
    {
        public static Expression BuildTree(string input)
        {
            var stack = new Stack<Expression>();
            foreach (var i in Parser.ToPostfix(input).Split(" "))
            {
                if (double.TryParse(i, out var variable))
                {
                    stack.Push(Expression.Constant(variable));
                }
                else
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    var node = i switch
                    {
                        "+" => Expression.Add(left, right),
                        "-" => Expression.Subtract(left, right),
                        "*" => Expression.Multiply(left, right),
                        "/" => Expression.Divide(left, right)
                    };
                    stack.Push(node);
                }
            }

            return stack.Pop();
        }
    }
}