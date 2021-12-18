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
        [InlineData("1%2b5%2b3","9")]
        [InlineData("5%2b3-2","6")]
        [InlineData("5%2b1%2b2*3","12")]
        [InlineData("5%2b%281%2b2%29*3","14")]
        [InlineData("6/3/2","1")]
        [InlineData("3","3")]
        public async Task Calculate_withCorrectValues_ReturnsCorrect(string expression, string expected)
        {
            await Test(expression, expected);
        }
    }
}