using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace hw6.Tests
{
   
    public class ProgramTests : IClassFixture<CustomWebApplicationFactory<Giraffe.App.Startup>>
    {
        private readonly CustomWebApplicationFactory<Giraffe.App.Startup> _factory;
        public ProgramTests (CustomWebApplicationFactory<Giraffe.App.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("1", "plus", "2", "3.0")]
        [InlineData("2.5", "minus", "5", "-2.5")]
        [InlineData("10", "divide", "4", "2.5")]
        [InlineData("100", "multiply", "0.8", "80.0")]
        public async Task DoRequest_And_ReturnCorrectValue(string arg1, string operation, string arg2, string expected)
        {
            await DoRequest(arg1, operation, arg2, expected);
        }
        
        [Theory]
        [InlineData("1", "%", "2", "\"Invalid operation.\"")]
        [InlineData("4", "plus", "a", "\"Invalid value.\"")]
        [InlineData("2", "divide", "0", "\"Division by zero\"")]
        public async Task DoWrongRequest_And_ReturnErrors(string arg1, string operation, string arg2, string expected)
        {
            await DoRequest(arg1, operation, arg2, expected);
        }

        private async Task DoRequest(string arg1, string operation, string arg2, string expected)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(
                $"http://localhost:5000/calculate?arg1={arg1}&operation={operation}&arg2={arg2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Request_Return_NotFound()
        {
            var client = _factory.CreateClient();
            var response =
                await client.GetAsync($"http://localhost:5000/sss");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal("Not Found", result);
        }

        [Fact]
        public async Task Request_Return_MissingValue()
        {
            var client = _factory.CreateClient();
            var response =
                await client.GetAsync($"https://localhost:5001/calculate?arg1=523114&operatio=/&arg2=43");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal("\"Missing value for required property operation.\"", result);
        }
        
    }
    
    //Setting WebApplicationFactory
    public class CustomWebApplicationFactory<TStartup>:
        WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.
                CreateDefaultBuilder()
                .ConfigureWebHostDefaults
                (conf =>
                { conf.UseStartup<Giraffe.App.Startup>().UseTestServer(); });
        }
    }
  
}
