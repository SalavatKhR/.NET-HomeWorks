using System;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace hw12
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MyBenchmarks>();
        }
    }
}