using Xunit;
using hw4;

namespace hw4Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, "+", 1, 2)]
        [InlineData(1, "-", 1, 0)]
        [InlineData(5, "*", 1, 5)]
        [InlineData(6, "/", 3, 2)]
        public void Calculate_Correctly(int val1, string operation, int val2, int expected)
        {
            var actual = Calculator.Calculate(val1, operation, val2);
            
            Assert.Equal(expected, actual);
        }
    }
}