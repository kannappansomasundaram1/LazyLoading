using System;
using System.Collections.Generic;
using System.Linq;
using static LinqChallenges.Utilities;

namespace LinqChallenges
{
    public class ItemsProvider
    {
        private readonly IReadOnlyList<string> _cachedItems;
        public ItemsProvider()
        {
            _cachedItems = new List<string> { "Cached Item 1", "Cached Item 2", "Cached Item 3" };
        }
        public IEnumerable<string> GetItems_1()
        {
            return GetItems();
        }

        public IReadOnlyCollection<string> GetItems_2()
        {
            return GetItems().ToList();
        }

        public List<string> GetItems_3()
        {
            return GetItems().ToList();
        }

        public IEnumerable<string> GetItems_4()
        {
            var items = GetItems()
                .ToList();
            items.ForEach(y => Console.WriteLine($"Publishing some metrics for item {y}"));
            return items;
        }

        public IEnumerable<string> GetCached_Items_1()
        {
            return _cachedItems;
        }

        public IReadOnlyCollection<string> GetCached_Items_2()
        {
            return _cachedItems;
        }

        public string FilterItems(IEnumerable<string> items)
        {
            return items.First(x => x.EndsWith("2"));
        }
    }
}