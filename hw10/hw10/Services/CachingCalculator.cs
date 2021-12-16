using hw10.Models;
using Microsoft.EntityFrameworkCore;

namespace hw10.Services
{
    public class CachingCalculator: CalculatorDecorator
    {
        protected CacheContext _context;
        protected CalculatorDecorator CalculatorDecorator;

        public CachingCalculator(CalculatorDecorator calculatorDecorator, CacheContext context)
        {
            _context = context;
            CalculatorDecorator = calculatorDecorator;
        }
        
        private Cache GetValue(string expr)
        {
            return _context.Cache.Find(expr);
        }
        
        public string CalculateWithCache(string input)
        {
            var fromCache = GetValue(input);
            if (fromCache != null)
            {
                return $"{fromCache.Value} (from cache)";
            }
            var result = CalculatorDecorator.Calculate(input);
            _context.Cache.Add(new Cache(input, result));
            _context.SaveChanges();
            return result;
        }
    }
}