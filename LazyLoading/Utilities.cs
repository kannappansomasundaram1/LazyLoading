using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LinqChallenges
{
    internal static class Utilities
    {
        public static void PrintCount(IEnumerable<string> todoList)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Total Items : {todoList.Count()}");
        }

        public static void PrintAllItems(IEnumerable<string> todoList)
        {
            var allItems = new StringBuilder();
            foreach (var todoItem in todoList)
                allItems.Append(todoItem + " ");
            Console.WriteLine(allItems.ToString());
            Console.WriteLine("----------------------------------");
        }

        public static IEnumerable<string> GetItems()
        {
            return Enumerable.Range(1, 5)
                .Select(x => {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Getting {x}");
                    return $"Item {x}";
                });
        }
    }
}