using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LazyLoading;

internal static class Utilities
{
    public static void PrintCount(IEnumerable<string> items)
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Counting Items");
        var count = items.Count();
        Console.WriteLine($"Total Items : {count}");
        Console.WriteLine("----------------------------------");
    }

    public static void PrintAllItems(IEnumerable<string> items)
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Printing all items");
        foreach (var item in items)
            Console.WriteLine(item);
        Console.WriteLine("----------------------------------");
    }

    public static IEnumerable<string> GetItems()
    {
        return Enumerable.Range(1, 5)
            .Select(x =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Getting {x}");
                return $"Item {x}";
            });
    }

    public static IEnumerable<Task<string>> GetItemsAsync()
    {
        return Enumerable.Range(1, 5)
            .Select(async x =>
            {
                Console.WriteLine($"Calling API to get {x}");
                await Task.Delay(1000);
                return $"Item {x}";
            });
    }
}