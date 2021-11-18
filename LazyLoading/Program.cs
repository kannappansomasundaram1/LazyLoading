using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using static LazyLoading.TimeRecorder;
using static LazyLoading.Utilities;

namespace LazyLoading;

public class Program
{
    static async Task Main(string[] args)
    {
        var examples = new Examples();
        var example = examples.
            Example_1;
            // Example_2;
            // Example_3;
            // Example_4;
            // Example_5;
            // Example_6;
            // Example_7;
            // Example_8;

            RecordTime(example);

        #region Async

            // Example_9();
            // Example_10();
        // await RecordTime(example);

        #endregion

        #region Benchmark

        // BenchmarkRunner.Run(typeof(Program).Assembly);

        #endregion
    }

    [MemoryDiagnoser]
    public class Examples
    {
        [Benchmark(Baseline = true)]
        public void Example_1()
        {
            var items = GetItems();
            PrintAllItems(items);
            PrintCount(items);
        }

        [Benchmark]
        public void Example_2()
        {
            var items = GetItems().ToArray();
            PrintAllItems(items);
            PrintCount(items);
        }

        public void Example_3()
        {
            var items = GetItems();
            PrintAllItems(items);
            if (items.Count() > 0)
                Console.WriteLine("Hurrah, we have some items");
        }

        public void Example_4()
        {
            var items = GetItems().ToArray();
            var firstEndingWith2 = items.First(item => item.EndsWith("2"));
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"First Item ending with 2: {firstEndingWith2}");
        }

        public void Example_5()
        {
            var firstEndingWith2 = GetItems().First(item => item.EndsWith("2"));
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"First Item ending with 2: {firstEndingWith2}");
        }

        public void Example_6()
        {
            var items = GetItems().ToArray();
            var Top3Items = items
                .Take(3)
                .Select(x => $"Transformed {x}")
                .ToArray();

            PrintAllItems(Top3Items);
            PrintCount(Top3Items);
        }

        public void Example_7()
        {
            var items = GetItems();
            var SortedItems = new SortedItems_1(items);

            Console.WriteLine($"First : {SortedItems.Items.First()}");
            Console.WriteLine($"Last  : {SortedItems.Items.Last()}");
        }

        public void Example_8()
        {
            var items = GetItems();
            var SortedItems = new SortedItems_2(items);
            Console.WriteLine($"First : {SortedItems.Items.First()}");
            Console.WriteLine($"Last  : {SortedItems.Items.Last()}");
        }

        public async Task Example_9()
        {
            var itemTasks = GetItemsAsync();

            Console.WriteLine("Watching final episode in a netflix series");
            Console.WriteLine("Finished watching final episode in a netflix series");

            foreach (var itemTask in itemTasks)
            {
                Console.WriteLine($"Got {await itemTask}");
            }

            foreach (var itemTask in itemTasks)
            {
                Console.WriteLine($"Processing {await itemTask}");
            }
        }

        public async Task Example_10()
        {
            var itemTasks = GetItemsAsync().ToArray();

            Console.WriteLine("Watching final episode in a netflix series");
            Console.WriteLine("Finished watching final episode in a netflix series");

            foreach (var itemTask in itemTasks)
            {
                Console.WriteLine($"Got {await itemTask}");
            }

            foreach (var itemTask in itemTasks)
            {
                Console.WriteLine($"Processing {await itemTask}");
            }
        }
    }
}