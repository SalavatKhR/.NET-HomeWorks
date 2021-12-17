using System;
using hw8.Services;
using Microsoft.AspNetCore.Mvc;

namespace hw8.Controllers
{
    public class CalculatorController: Controller
    {
        [HttpGet, Route("calculate")]
        public IActionResult Calculate([FromServices] ICalculator calculator, string arg1, string op, string arg2)
        {
            string url = $"https://localhost:5001/calculate?arg1={arg1}&op={op}&arg2={arg2}";
            string encodedUrl = Uri.UnescapeDataString(url);
            return Content(encodedUrl);
            //return Content(calculator.Calculate(arg1, op, arg2));
        }

        private static string GetRequest(string arg1, string op, string arg2)
        {
            op = op == "+" ? "%2b" : op;
            return $"https://localhost:5001/calculate?arg1={arg1}&op={op}&arg2={arg2}";
        }
    }
}