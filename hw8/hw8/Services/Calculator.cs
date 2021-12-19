namespace hw8.Services
{
    public class Calculator: ICalculator
    {
        public bool TryParseArgs(string arg1, string arg2, out double val1, out double val2)
        {
            var isVal1double = double.TryParse(arg1, out val1);
            var isVal2double = double.TryParse(arg2, out val2);
            return isVal1double && isVal2double;
        }
        public string Calculate(string arg1, string op, string arg2)
        {
            var isValidArgs = TryParseArgs(arg1, arg2, out var val1, out var val2);
            string result;
            if(isValidArgs)
                result = op switch
                {
                    "+" => $"{val1 + val2}",
                    "-" => $"{val1 - val2}",
                    "*" => $"{val1 * val2}",
                    "/" => (val2 != 0) ? $"{val1 / val2}" : "Divide by zero!",
                    _ => "Wrong operation!"
                };
            else
            {
                result = "Wrong arguments!";
            }
            
            return result ;
        }
    }
}