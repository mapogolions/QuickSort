using System.Threading.Tasks;
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

        public static IList<TSource> ParallelSort<TSource>(IList<TSource> source, int depth = -1)
             where TSource : IComparable<TSource>
        {
            var count = source.Count();
            if (count is 0) return new List<TSource>();
            if (count is 1) return new List<TSource> { source.First() };
            var first = source.First();
            var (smaller, largerOrEqual) = source.Partition(x => x.CompareTo(first) == -1);
            var sortedList = new List<TSource>(count);
            if (depth > 0)
            {
                var t1 = Task.Run(() => ParallelSort(smaller, depth - 1));
                var t2 = Task.Run(() => ParallelSort(largerOrEqual.Skip(1).ToList(), depth - 1));
                Task.WaitAll(t1, t2);
                sortedList.AddRange(t1.Result);
                sortedList.Add(first);
                sortedList.AddRange(t2.Result);
            }
            else
            {
                sortedList.AddRange(ParallelSort(smaller));
                sortedList.Add(first);
                sortedList.AddRange(ParallelSort(largerOrEqual.Skip(1).ToList()));
            }
            return sortedList;
        }
    }
}
