namespace UiServer.Models
{
    public class Parser
    {
        public static string SplitCamelCase(string input)
        {
            var result = "";
            var wasCapital = false;
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (char.IsUpper(input[i + 1]))
                {
                    result += input[i] + " " + input[i + 1];
                    wasCapital = true;
                    continue;
                }
                if (wasCapital)
                {
                    wasCapital = false;
                }
                else result += input[i];
            }
            result += input[^1];
            return result;
        }
    }
}