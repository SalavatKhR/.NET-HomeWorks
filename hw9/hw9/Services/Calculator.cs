using System.Linq.Expressions;
using System.Threading.Tasks;
using hw9.ExpressionTree;

namespace hw9.Services
{
    class Calculator: ICalculator
    {

            public string Calculate(Expression expression)
            {
                return CalclateAsync(expression).Result.ToString();
            }

            public async Task<double> CalclateAsync(Expression node)
            {
                if (node is ConstantExpression constant)
                {
                    if (constant.Value != null) 
                        return await Task.FromResult((double) constant.Value);
                }
            
                var binaryNode = (BinaryExpression) node;
                var left = CalclateAsync(binaryNode.Left);
                var right = CalclateAsync(binaryNode.Right);
                Task.WaitAll(left, right);
            
                return binaryNode.NodeType switch
                {
                    ExpressionType.Add => left.Result + right.Result,
                    ExpressionType.Subtract => left.Result - right.Result,
                    ExpressionType.Multiply => left.Result * right.Result,
                    ExpressionType.Divide => left.Result / right.Result,
                };
            }
    }
}