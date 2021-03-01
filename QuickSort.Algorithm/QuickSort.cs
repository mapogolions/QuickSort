namespace QuickSort.Algorithm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class QuickSort
    {
        public static IList<TSource> Sort<TSource>(IList<TSource> source) where TSource : IComparable<TSource>
        {
            var count = source.Count();
            if (count is 0) return new List<TSource>();
            if (count is 1) return new List<TSource> { source.First() };
            var first = source.First();
             var (smaller, largerOrEqual) = source.Partition(x => x.CompareTo(first) == -1);
            var sortedList = new List<TSource>(count);
            sortedList.AddRange(Sort(smaller));
            sortedList.Add(first);
            sortedList.AddRange(Sort(largerOrEqual.Skip(1).ToList()));
            return sortedList;
        }
    }
}
