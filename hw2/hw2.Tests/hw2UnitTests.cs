using hw2;
using Xunit;
using hw2IL;

namespace hw1.Tests
{
    public class hw2UnitTests
    {
        [Theory]
        [InlineData(1, "+", 2, 3)]
        [InlineData(7, "-", 2, 5)]
        [InlineData(2, "*", 4, 8)]
        [InlineData(14, "/", 2, 7)]
        [InlineData(10, "l", 3, 0)]
        public void Calculate_Correctly(double val1, string operation, double val2, double expected)
        {
            var actual = Calculalator.Calculate(val1, operation, val2);
            
            Assert.Equal(expected, actual);
        }
        
        [Theory] 
        [InlineData(new []{"1", "+", "3"}, 0)]
        [InlineData(new []{"1", ".", "3"}, 2)]
        [InlineData(new []{"v", "-", "3"}, 1)]
        [InlineData(new []{"5", "/", "0"}, 3)]
        public void TryParseArguments_Correctly(string[] args, int expected)
        {
            var actual = ParserIl.TryParseArguments(args, out double val1, out string operation, out double val2);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new []{ "1", "+", "3" }, 0)]
        [InlineData(new []{ "g", "+", "3" }, 1)]
        [InlineData(new []{ "1", ".", "3" }, 2)]
        public void Program_Correctly(string[] args, int expected)
        {
            var actual = Program.Main(args);

            Assert.Equal(expected, actual);
        }
    }
}