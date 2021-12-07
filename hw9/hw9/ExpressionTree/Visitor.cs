using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hw9.ExpressionTree
{
    public class Visitor: ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var result = ProcessInParallel(node.Left, node.Right).Result;
            return node.NodeType switch
            {
                ExpressionType.Add => Expression.Add(Expression.Constant(result[0]) ,Expression.Constant(result[1])),
                ExpressionType.Subtract => Expression.Subtract(Expression.Constant(result[0]) ,Expression.Constant(result[1])),
                ExpressionType.Multiply => Expression.Multiply( Expression.Constant(result[0]) ,Expression.Constant(result[1])),
                ExpressionType.Divide => Expression.Divide(Expression.Constant(result[0]), Expression.Constant(result[1]))
            };
        }

        private static async Task<double[]> ProcessInParallel(Expression left, Expression right)
        {
            return await Task.WhenAll(
                Task.Run(() => Expression.Lambda<Func<double>>(left).Compile().Invoke()),
                Task.Run(() => Expression.Lambda<Func<double>>(right).Compile().Invoke()));
        }
    }
}