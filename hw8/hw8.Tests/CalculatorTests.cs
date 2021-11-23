using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace hw8.Tests
{
    public class CalculatorTests
    {
        
        private WebApplicationFactory<Startup> factory;
        private HttpClient client;
        
        public CalculatorTests()
        {
            factory = new WebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }

        public async Task Test(string arg1, string operation, string arg2, string expected)
        {
            var respones = await client.GetAsync(
                $"/calculate?arg1={arg1}&op={operation}&arg2={arg2}");
            var actual = await respones.Content.ReadAsStringAsync();
            Assert.Equal(expected, actual);
        }
        
        
        
        [Theory]
        [InlineData("1","2","3")]
        [InlineData("-4","2","-2")]
        [InlineData("-2","4","2")]
        [InlineData("1,2","2,3","3,5")]
        [InlineData("5","0","5")]
        public async Task Add_withCorrectValues_ReturnsCorrect(string arg1, string arg2, string expected)
        {
            await Test(arg1, "plus", arg2, expected);
        }
        
        [Theory]
        [InlineData("5","2","3")]
        [InlineData("5","-2","7")]
        [InlineData("-2","0","-2")]
        [InlineData("5","2,5","2,5")]
        [InlineData("3","0", "3")]
        public async Task Substract_withCorrectValues_ReturnsCorrect(string arg1, string arg2, string expected)
        {
            await Test(arg1, "minus", arg2, expected);
        }

        [Theory]
        [InlineData("5","2","10")]
        [InlineData("5","-2","-10")]
        [InlineData("-2","0","-0")]
        [InlineData("2","2,5","5")]
        [InlineData("0,5","0,5","0,25")]
        public async Task Multiply_withCorrectValues_ReturnsCorrect(string arg1, string arg2, string expected)
        {
            await Test(arg1, "multiply", arg2, expected);
        }
        
        [Theory]
        [InlineData("5","2","2,5")]
        [InlineData("5","0,5","10")]
        [InlineData("-2","-1","2")]
        [InlineData("2","5","0,4")]
        public async Task Divide_withCorrectValues_ReturnsCorrect(string arg1, string arg2, string expected)
        {
            await Test(arg1, "divide", arg2, expected);
        }
        
        [Theory]
        [InlineData("a","plus","2", "Wrong arguments!")]
        [InlineData("5","minus","b", "Wrong arguments!")]
        [InlineData("-2","df","0", "Wrong operation!")]
        [InlineData("5","divide","0","Divide by zero!")]
        public async Task Calculate_withInCorrectValues(string arg1, string operation, string arg2, string expected)
        {
            await Test(arg1, operation, arg2, expected);
        }
    }
}