using System.Linq.Expressions;
using System.Threading.Tasks;
using hw11.ExpressionTree;

namespace hw11.Services
{
    public class CalculatorDecorator: ICalculator
    {
        public string Calculate(string expression)
        {
            var expressionTree = ExpressionTreeBuilder.BuildTree(expression);
            return CalclateAsync(expressionTree).Result.ToString();
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