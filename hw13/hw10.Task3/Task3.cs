using System;
using Xunit;
using System.Net.Http;
using System.Text;
using JetBrains.dotMemoryUnit;
using JetBrains.dotMemoryUnit.Kernel;
using Microsoft.AspNetCore.Mvc.Testing;
using hw10;
using Xunit;
using Xunit.Abstractions;

namespace hw10.Task3
{
    public class Task3
    {
        private readonly ITestOutputHelper _writer;
        private readonly HttpClient _client = new WebApplicationFactory<Startup>().CreateClient();

        public Task3(ITestOutputHelper writer)
        {
            _writer = writer;
            DotMemoryUnitTestOutput.SetOutputMethod(_writer.WriteLine);
        }

        [DotMemoryUnit(CollectAllocations = true, FailIfRunWithoutSupport = false)]
        [Fact]
        public void Test1()
        {
            var point = dotMemory.Check();
        
            long allocated = 0;
            for (long i = 0; i < 100000; ++i)
            {
                var str = $"{i}+{i}";
                allocated += Encoding.UTF8.GetBytes(str).Length;
                _client.GetAsync($"https://localhost:5001/calculate?input={str}").GetAwaiter().GetResult();
            }

            dotMemory.Check(memory =>
            {
                _writer.WriteLine(memory.GetTrafficFrom(point).CollectedMemory.SizeInBytes.ToString());
                _writer.WriteLine(allocated.ToString());
                Assert.True(memory.GetTrafficFrom(point).CollectedMemory.SizeInBytes >= allocated);
            });
        }
    }
}