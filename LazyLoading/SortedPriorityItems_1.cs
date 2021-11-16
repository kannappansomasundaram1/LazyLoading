using System.Collections.Generic;
using System.Linq;

namespace LinqChallenges
{
    public class SortedPriorityItems_1
    {
        public IEnumerable<PriorityItems> PriorityItems { get; }

        public SortedPriorityItems_1(IEnumerable<PriorityItems> priorityItems)
        {
            PriorityItems = priorityItems.OrderByDescending(x => x.Priority);
        }
    }

    public class SortedPriorityItems_2
    {
        public IReadOnlyCollection<PriorityItems> PriorityItems { get; }

        public SortedPriorityItems_2(IEnumerable<PriorityItems> priorityItems)
        {
            PriorityItems = priorityItems.OrderByDescending(x => x.Priority).ToList();
        }
    }

    public class PriorityItems
    {
        public string Item { get; init; }
        public int Priority { get; init; }

        public override string ToString()
        {
            return $"{Priority} - {Item}";
        }
    }
}