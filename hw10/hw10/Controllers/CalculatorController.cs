using hw10.Models;
using hw10.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hw10.Controllers
{
    public class CalculatorController: Controller
    {
        private CacheContext _context;

        public CalculatorController(CacheContext context)
        {
            _context = context;
        }
        
        
        [HttpGet, Route("calculate")]
        public IActionResult Calc(string input)
        {
            var calc = new CachingCalculator(new CalculatorDecorator(), _context);
            var result = calc.CalculateWithCache(input);
            return Content(result);
        }
    }
}