using CalculatorCS;
using Xunit;

namespace hw4Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(new[] {"6", "-", "4"}, 0)]
        [InlineData(new[] {"a", "+", "b"}, 1)]
        [InlineData(new[] {"21", ".", "7"}, 2)]
        [InlineData(new[] {"25", "/", "0"}, 3 )]
        public void Main_Correctly(string[] args, int expected)
        {
            // Arrange & act
            var actual = Program.Main(args);
            
            // Assert
            Assert.Equal(expected, actual);
        }
        
    }
}