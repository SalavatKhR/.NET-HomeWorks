using System;
using System.Linq.Expressions;
using hw9.ExpressionTree;
using hw9.Services;
using Microsoft.AspNetCore.Mvc;

namespace hw9.Controllers
{
    public class CalculatorController : Controller
    {
            [HttpGet, Route("calculate")]
            public IActionResult Calc(string input)
            {
                var expressionTree = ExpressionTreeBuilder.BuildTree(input);
                var result = Expression.Lambda<Func<double>>(new Visitor().Visit(expressionTree)).Compile().Invoke();
                //var result = calc.Calculate(expressionTree);
                return Content(result.ToString());
            }
    }
}