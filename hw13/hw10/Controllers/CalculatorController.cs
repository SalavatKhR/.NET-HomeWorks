using System.Collections.Generic;
using hw10.Models;
using hw10.Calculator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hw10.Controllers
{
    public class CalculatorController: Controller
    {
        private readonly ICachingCalculator _calculator;


        public CalculatorController([FromServices]ICachingCalculator calculator)
        {
            _calculator = calculator;
        }
        
        
        [HttpGet, Route("calculate")]
        public IActionResult Calc(string input)
        {
            var result =  _calculator.CalculateWithCache(input);
            return Content(result);
        }
    }
}