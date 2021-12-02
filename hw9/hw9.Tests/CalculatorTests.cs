using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace hw9.Tests
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
        public async Task Test(string expression, string expected)
        {
            var response = await client.GetAsync(
                $"/calculate?input={expression}");
            var actual = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("1plus5plus3","9")]
        [InlineData("5plus3minus2","6")]
        [InlineData("5plus1plus2multiply3","12")]
        [InlineData("5plus%281plus2%29multiply3","14")]
        [InlineData("6divide3divide2","1")]
        [InlineData("3","3")]
        public async Task Calculate_withCorrectValues_ReturnsCorrect(string expression, string expected)
        {
            await Test(expression, expected);
        }
    }
}