using System.Collections.Generic;

namespace LazyLoading;

public class ItemsProvider
{
    private readonly string[] _cachedItems;

    public ItemsProvider()
    {
        _cachedItems = new[] {"Cached Item 1", "Cached Item 2", "Cached Item 3"};
    }

    public IEnumerable<string> GetCached_Items()
    {
        return _cachedItems;
    }
}