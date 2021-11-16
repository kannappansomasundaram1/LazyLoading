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
                // ConsumingACollection_1;
                // ConsumingACollection_2;
                // ConsumingACollection_3;
                // GettingAnItem_1;
                // GettingAnItem_2;
                // PassingCollection_1;
                // PassingCollection_2;
                // AccessingAProperty_1;
                // AccessingAProperty_2;
                ConsumingCollectionFromAnotherClass_1;
                // ConsumingCollectionFromAnotherClass_IEnumerable1;
                // ConsumingCollectionFromAnotherClass_2;
                // ConsumingCollectionFromAnotherClass_3;
                // ConsumingCachedCollectionFromAnotherClass_1;
                // ConsumingCachedCollectionFromAnotherClass_2;

            #region TimeRecording
            TimeRecorder.RecordTime(example);
            #endregion
        }

        private static void ConsumingACollection_1()
        {
            var items = GetItems();
            PrintAllItems(items);
            PrintCount(items);
        }

        private static void ConsumingACollection_2()
        {
            var items = GetItems().ToArray();
            PrintAllItems(items);
            PrintCount(items);
        }

        private static void ConsumingACollection_3()
        {
            var items = GetItems();
            PrintAllItems(items);
            if (items.Count() > 0)
            {
                Console.WriteLine("Hurrah, we have some items");
            }
        }

        private static void PassingCollection_1()
        {
            var items = GetItems();
            var filteredItem = new ItemsProvider().FilterItems(items.ToList());
            Console.WriteLine($"filtered Item : {filteredItem}");
        }

        private static void PassingCollection_2()
        {
            var items = GetItems();
            var filteredItem = new ItemsProvider().FilterItems(items);
            Console.WriteLine($"filtered Item : {filteredItem}");
        }

        private static void AccessingAProperty_1()
        {
            var items = GetItems()
                .Select((x, i) =>
                    new PriorityItems {Item = x, Priority = i+1 });
            var sortedByPriority = new SortedPriorityItems_1(items);
            Console.WriteLine($"count : {sortedByPriority.PriorityItems.Count()}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"First : {sortedByPriority.PriorityItems.First()}");
        }

        private static void AccessingAProperty_2()
        {
            var items = GetItems()
                .Select((x, i) =>
                    new PriorityItems {Item = x, Priority = i+1 });
            var sortedByPriority = new SortedPriorityItems_2(items);
            Console.WriteLine($"count : {sortedByPriority.PriorityItems.Count()}");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"First : {sortedByPriority.PriorityItems.First()}");
        }

        private static void GettingAnItem_1()
        {
            var items = GetItems().ToArray();
            var firstEndingWith2 = items.First(item => item.EndsWith("2"));
            Console.WriteLine("----------------------------");
            Console.WriteLine($"First Item ending with 2: {firstEndingWith2 }");
        }

        private static void GettingAnItem_2()
        {
            var firstEndingWith2 = GetItems().First(item => item.EndsWith("2"));
            Console.WriteLine("----------------------------");
            Console.WriteLine($"First Item ending with 2: {firstEndingWith2 }");
        }

        private static void ConsumingCollectionFromAnotherClass_1()
        {
            var items = new ItemsProvider().GetItems_1();
            PrintAllItems(items);
            PrintCount(items);
        }

        private static void ConsumingCollectionFromAnotherClass_IEnumerable1()
        {
            var items = new ItemsProvider().GetItems_1().ToList();
            var Top3Items = items.Take(3).Select(x =>
            {
                var s = $"Transformed {x}";
                Console.WriteLine(s);
                return s;
            }).ToList();

            PrintAllItems(Top3Items);
            PrintCount(Top3Items);
        }

        private static void ConsumingCollectionFromAnotherClass_2()
        {
            #region Comments
            // It gives your caller the ability to access the count of items
            // and iterate through as many times as they like,
            // but doesn't allow them to modify that collection
            #endregion
            var items = new ItemsProvider().GetItems_2();
            PrintAllItems(items);
            PrintCount(items);
        }

        private static void ConsumingCollectionFromAnotherClass_3()
        {
            #region Comments
            // It gives your caller the ability to access the count of items
            // and iterate through as many times as they like,
            // but allow them to modify that collection
            #endregion
            var items = new ItemsProvider().GetItems_3();
            items.Add("Item 99");
            PrintAllItems(items);
            PrintCount(items);
        }

        private static void ConsumingCollectionFromAnotherClass_4()
        {
            #region Comments
            // Consumer is not aware that the collection is materialized
            // To be on the safer side they materialize it again
            // It's wasteful
            #endregion
            var items = new ItemsProvider().GetItems_4().ToList();
            PrintAllItems(items);
            PrintCount(items);
        }

        private static void ConsumingCachedCollectionFromAnotherClass_1()
        {
            #region Comments
            //Doesn't clearly state the collection is in memory.
            //Callers materialize the collection assuming multiple enumeration could happen
            #endregion
            var items = new ItemsProvider().GetCached_Items_1().ToList();
            PrintAllItems(items);
            PrintCount(items);
        }

        private static void ConsumingCachedCollectionFromAnotherClass_2()
        {
            #region Comments
            //Explicitly state the collection is in memory.
            //Avoids caller to materialize the collection
            #endregion
            var items = new ItemsProvider().GetCached_Items_2();
            PrintAllItems(items);
            PrintCount(items);
        }
    }
}