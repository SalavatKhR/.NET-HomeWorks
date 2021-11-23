using hw8.Services;
using Microsoft.AspNetCore.Mvc;

namespace hw8.Controllers
{
    public class CalculatorController: Controller
    {
        [HttpGet, Route("calculate")]
        public IActionResult Calculate([FromServices] ICalculator calculator, string arg1, string op, string arg2)
        {
            return Content(calculator.Calculate(arg1, op, arg2));
        }
    }
}