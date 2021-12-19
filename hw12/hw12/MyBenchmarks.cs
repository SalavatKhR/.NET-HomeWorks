using System;
using System.Net.Http;
using BenchmarkDotNet.Attributes;
using Giraffe;
using hw8;
using hw8.Services;
using Microsoft.AspNetCore.Mvc.Testing;

namespace hw12
{
    [MinColumn]
    [MaxColumn]
    [StdDevColumn]
    [StdErrorColumn]
    [MedianColumn]
    public class MyBenchmarks: IDisposable
    {
        private CustomWebApplicationFactory<App.Startup> _fSharpFactory;
        private HttpClient _fSharpClient;
        private WebApplicationFactory<Startup> _cSharpFactory;
        private HttpClient _cSharpClient;

        [GlobalSetup]
        public void GlobalSetUp()
        {
            _fSharpFactory = new CustomWebApplicationFactory<App.Startup>();
            _fSharpClient = _fSharpFactory.CreateClient();
            _cSharpFactory = new WebApplicationFactory<Startup>();
            _cSharpClient = _cSharpFactory.CreateClient();
        }
        
        private HttpRequestMessage FSharp111Plus222Message =>
            new(HttpMethod.Get, "https://localhost:5001/calculate?arg1=111&operation=plus&arg2=222");
        private HttpRequestMessage FSharp222Minus111Message =>
            new(HttpMethod.Get, "https://localhost:5001/calculate?arg1=222&operation=minus&arg2=111");
        private HttpRequestMessage FSharp111Multiply2Message =>
            new(HttpMethod.Get, "https://localhost:5001/calculate?arg1=111&operation=multiply&arg2=2");
        private HttpRequestMessage FSharp222Divide111Message =>
            new(HttpMethod.Get, "https://localhost:5001/calculate?arg1=222&operation=divide&arg2=111");
        
        
        [Benchmark(Description = "F# 111 + 222")]
        public void FSharpPlus()
        {
            var r1 = _fSharpClient.SendAsync(FSharp111Plus222Message).GetAwaiter().GetResult();
        }
        
        [Benchmark(Description = "F# 111 * 2")]
        public void FSharpMultiply()
        {
            var r1 = _fSharpClient.SendAsync(FSharp111Multiply2Message).GetAwaiter().GetResult();
        }
        
        [Benchmark(Description = "F# 222 - 111")]
        public void FSharpMinus()
        {
            var r1 = _fSharpClient.SendAsync(FSharp222Minus111Message).GetAwaiter().GetResult();
        }

        [Benchmark(Description = "F# 222 / 111")]
        public void FSharpDivide()
        {
            var r1 = _fSharpClient.SendAsync(FSharp222Divide111Message).GetAwaiter().GetResult();
        }
        
        private HttpRequestMessage CSharp111Plus222Message =>
            new(HttpMethod.Get, "https://localhost:5001/calculate?arg1=111&op=plus&arg2=222");
        private HttpRequestMessage CSharp222Minus111Message =>
            new(HttpMethod.Get, "https://localhost:5001/calculate?arg1=222&op=minus&arg2=111");
        private HttpRequestMessage CSharp111Multiply2Message =>
            new(HttpMethod.Get, "https://localhost:5001/calculate?arg1=111&op=multiply&arg2=2");
        private HttpRequestMessage CSharp222Divide111Message =>
            new(HttpMethod.Get, "https://localhost:5001/calculate?arg1=222&op=divide&arg2=111");
        
        [Benchmark(Description = "C# 111 + 222")]
        public void CSharpPlus()
        {
            var r1 = _cSharpClient.SendAsync(CSharp111Plus222Message).GetAwaiter().GetResult();
        }
        
        [Benchmark(Description = "C# 222 - 111")]
        public void CSharpMinus()
        {
            var r1 = _cSharpClient.SendAsync(CSharp222Minus111Message).GetAwaiter().GetResult();
        }
        
        [Benchmark(Description = "C# 111 * 2")]
        public void CSharpMultiply()
        {
            var r1 = _cSharpClient.SendAsync(CSharp111Multiply2Message).GetAwaiter().GetResult();
        }
        
        [Benchmark(Description = "C# 222 / 111")]
        public void CSharpDivide()
        {
            var r1 = _cSharpClient.SendAsync(CSharp222Divide111Message).GetAwaiter().GetResult();
        }

        [GlobalCleanup]
        public void Dispose()
        {
            _fSharpClient?.Dispose();
            _fSharpFactory?.Dispose();
            _cSharpClient?.Dispose();
            _cSharpFactory?.Dispose();
        }
    }
}