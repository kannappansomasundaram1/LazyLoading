using System.Collections.Generic;
using System.Linq;

namespace LazyLoading;

public class SortedItems_1
{
    public IEnumerable<string> Items { get; }

    public SortedItems_1(IEnumerable<string> priorityItems)
    {
        Items = priorityItems.OrderByDescending(x => x);
    }
}

public class SortedItems_2
{
    public IReadOnlyCollection<string> Items { get; }

    public SortedItems_2(IEnumerable<string> priorityItems)
    {
        Items = priorityItems.OrderByDescending(x => x).ToArray();
    }
}