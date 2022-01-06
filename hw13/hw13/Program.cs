using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using hw13;

BenchmarkRunner.Run<Benchmarks>();

namespace hw13
{
    public class DifferenMethods
    {
        public string Simple(int value) => value.ToString();
        public virtual string Virtual(int value) => value.ToString();
        public static string Static(int value) => value.ToString();
        public string Generic<T>(T value) => value.ToString();  
        public string Dynamic(dynamic value) => value.ToString();
        public string Reflection(int value) =>
            (string) typeof(DifferenMethods)
                .GetMethod(nameof(Simple))?
                .Invoke(new DifferenMethods(), new object[] {value})!;
    }
    [MemoryDiagnoser]
    [MinColumn]
    [MaxColumn]
    [StdDevColumn]
    [StdErrorColumn]
    [MedianColumn]
    public class Benchmarks
    {
        private DifferenMethods _methods;
        private const int Value = 1234;

        [GlobalSetup]
        public void Setup()
        {
            _methods = new DifferenMethods();
        }

        [Benchmark (Description = "Simple")] 
        public void Simple() => _methods.Simple(Value);
        [Benchmark (Description = "Virtual")]
        public void Virtual() => _methods.Virtual(Value);
        [Benchmark (Description = "Static")] 
        public void Static() => DifferenMethods.Static(Value);
        [Benchmark (Description = "Generic")] 
        public void Generic() => _methods.Generic(Value);
        [Benchmark (Description = "Dynamic")] 
        public void Dynamic() => _methods.Dynamic(Value);
        [Benchmark (Description = "Reflection")] 
        public void Reflection() => _methods.Reflection(Value);
    }
}