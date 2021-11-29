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
            public IActionResult Calc([FromServices] ICalculator calc, string input)
            {
                var result = calc.Calculate(input);
                return Content(result);
            }
    }
}