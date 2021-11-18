using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static LinqChallenges.Utilities;

namespace LinqChallenges
{
    [SuppressMessage("ReSharper", "UseMethodAny.0")]
    class Program
    {
        static void Main(string[] args)
        {
            Action example =
                // Example_1;
                // Example_2;
                Example_3;
                // Example_4;
                // Example_5;
                // Example_6;
                // Example_7;
                // Example_8;
                // Example_9;
                // Example_10;
                // Example_11;

            TimeRecorder.RecordTime(example);

        }

        private static void Example_1()
        {
            var items = GetItems().ToList();
            PrintAllItems(items);
            PrintCount(items);
        }

        private static void Example_2()
        {
            var items = GetItems();
            PrintAllItems(items);
            PrintCount(items);
        }

        private static void Example_3()
        {
            var items = GetItems();
            PrintAllItems(items);
            if (items.Count() > 0)
                Console.WriteLine("Hurrah, we have some items");
        }

        private static void Example_4()
        {
            var items = GetItems().ToArray();
            var firstEndingWith2 = items.First(item => item.EndsWith("2"));
            Console.WriteLine("----------------------------");
            Console.WriteLine($"First Item ending with 2: {firstEndingWith2 }");
        }

        private static void Example_5()
        {
            var firstEndingWith2 = GetItems().First(item => item.EndsWith("2"));
            Console.WriteLine("----------------------------");
            Console.WriteLine($"First Item ending with 2: {firstEndingWith2 }");
        }

        private static void Example_6()
        {
            var items = GetItems().ToList();
            var filteredItem = new ItemsProvider().FilterItems(items);
            Console.WriteLine($"filtered Item : {filteredItem}");
        }

        private static void Example_7()
        {
            var items = GetItems();
            var filteredItem = new ItemsProvider().FilterItems(items);
            Console.WriteLine($"filtered Item : {filteredItem}");
        }

        private static void Example_8()
        {
            var items = GetItems()
                .Select((x, i) =>
                    new PriorityItems {Item = x, Priority = i+1 });
            var sortedByPriority = new SortedPriorityItems_1(items);
            Console.WriteLine($"count : {sortedByPriority.PriorityItems.Count()}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"First : {sortedByPriority.PriorityItems.First()}");
        }

        private static void Example_9()
        {
            var items = GetItems()
                .Select((x, i) =>
                    new PriorityItems {Item = x, Priority = i+1 });
            var sortedByPriority = new SortedPriorityItems_2(items);
            Console.WriteLine($"count : {sortedByPriority.PriorityItems.Count()}");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"First : {sortedByPriority.PriorityItems.First()}");
        }

        private static void Example_10()
        {
            var items = GetItems().ToList();
            var Top3Items = items.Take(3).Select(x =>
            {
                var s = $"Transformed {x}";
                Console.WriteLine(s);
                return s;
            }).ToList();

            PrintAllItems(Top3Items);
            PrintCount(Top3Items);
        }

        private static void Example_11()
        {
            #region Comments
            //Doesn't clearly state the collection is in memory.
            //Callers materialize the collection assuming multiple enumeration could happen
            #endregion
            var items = new ItemsProvider().GetCached_Items_1().ToList();
            PrintAllItems(items);
            PrintCount(items);
        }
    }
}