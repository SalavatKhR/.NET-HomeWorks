using System;
using Xunit;
using Homework1;

namespace Homework1Tests
{
    public class HW1UnitTests
    {
        [Theory]
        [InlineData(1, "+", 2, 3)]
        [InlineData(7, "-", 2, 5)]
        [InlineData(2, "*", 4, 8)]
        [InlineData(14, "/", 2, 7)]
        [InlineData(10, "l", 3, 0)]
        public void Should_Calculate_Correctly(int val1, string operation, int val2, double expected)
        {
            var actual = Calculator.Calculate(val1, operation, val2);
            
            Assert.Equal(expected, actual);
        }
        
        [Theory] 
        [InlineData(new string[] {"1", "+", "3"}, 0)]
        [InlineData(new string[] {"1", ".", "3"}, 2)]
        [InlineData(new string[] {"v", "-", "3"}, 1)]
        public void Should_TryParseArguments_Correctly(string[] args, int expected)
        {
            var actual = Parser.TryParseArguments(args,  out int val1, out string operation, out int val2);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new string[] { "1", "+", "3" }, 0)]
        [InlineData(new string[] { "g", "+", "3" }, 1)]
        [InlineData(new string[] { "1", ".", "3" }, 2)]
        public void Should_Program_Correctly(string[] args, int expected)
        {
            var actual = Program.Main(args);

            Assert.Equal(expected, actual);
        }
    }
}
