using System;
using System.Linq.Expressions;
using hw11.ExceptionHandler;
using hw11.ExpressionTree;
using hw11.Models;
using hw11.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hw11.Controllers
{
    public class CalculatorController: Controller
    {
        private CacheContext _context;
        private ILogger<CalculatorController> _logger;

        public CalculatorController(CacheContext context, ILogger<CalculatorController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        
        [HttpGet, Route("calculate")]
        public IActionResult Calc(string input)
        {
            IExceptionHandler handler = new ExceptionHandler.ExceptionHandler(_logger);
            try
            {
                var expressionTree = ExpressionTreeBuilder.BuildTree(input);
                var result = Expression.Lambda<Func<double>>(new Visitor().Visit(expressionTree)).Compile().Invoke();
                return Content(result.ToString());
            }
            catch (Exception e)
            {
                handler.HandleException(e);
                return Content("Check Log");
            }
        }
    }
}