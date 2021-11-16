using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace LazyLoading.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }


    }

    [MemoryDiagnoser()]
    public class MyClass
    {
        [Benchmark(Baseline = true)]
        public void GetCount1()
        {
            var items = GetItems().ToList();
            var Top3Items = items.Take(3).Select(Transform).ToList();

            PrintCount(Top3Items);
        }

        [Benchmark]
        public void GetCount2()
        {
            var items = GetItems();
            var Top3Items = items.Take(3).Select(Transform).ToList();

            PrintCount(Top3Items);
        }

        private static string Transform(string x)
        {
            var s = $"Transformed {x}";
            return s;
        }

        private void PrintCount(IEnumerable<string> top3Items)
        {
            top3Items.Count();
        }

        private IEnumerable<string> GetItems()
        {
            return Enumerable.Range(1, 10)
                .Select(x => $"Item {x}");
        }

    }
}