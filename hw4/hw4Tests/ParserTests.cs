using Xunit;
using hw4;

namespace hw4Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData(new[] {"2", "+", "3"}, 0)]
        [InlineData(new[] {"6", "-", "4"}, 0)]
        public void ParseCorrectly_WhenRightArguments(string[] args, int expected)
        {
            var actual = Parser.TryParseArguments(args, out var val1,
                out var operation, out var val2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {"a", "+", "3"}, 1)]
        [InlineData(new[] {"aa", "+", "bb"}, 1)]
        [InlineData(new[] {"1", "k", "2"}, 2)]
        [InlineData(new[] {"3", "?", "4"}, 2)]
        [InlineData(new[] {"3", "/", "0"}, 3)]
        public void Parse_WhenWrongArguments(string[] args, int expected)
        {
            var actual = Parser.TryParseArguments(args, out var val1,
                out var operation, out var val2);

            Assert.Equal(expected, actual);
        }
    }
}