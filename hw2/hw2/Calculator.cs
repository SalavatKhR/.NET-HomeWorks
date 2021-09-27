namespace hw2
{
    public static class Calculator
    {
        public static double Calculate(double val1, string operation, double val2)
        {
            var result = operation switch
            {
                "+" => val1 + val2,
                "-" => val1 - val2,
                "*" => val1 * val2,
                "/" => val1 / val2,
                _ => 0
            };
            return result;
        }
    }
}