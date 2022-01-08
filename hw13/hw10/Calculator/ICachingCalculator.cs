namespace hw10.Calculator
{
    public interface ICachingCalculator
    {
        public string Calculate(string input);
        public string CalculateWithCache(string input);
    }
}