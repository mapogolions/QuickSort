namespace QuickSort.Algorithm
{
    using System;
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        public static Tuple<IList<TSource>, IList<TSource>> Partition<TSource>(this IEnumerable<TSource> @this,
            Predicate<TSource> test)
        {
            var succeeded = new List<TSource>();
            var failed = new List<TSource>();
            foreach (var item in @this)
            {
                if (test(item))
                {
                    succeeded.Add(item);
                    continue;
                }
                failed.Add(item);
            }
            return new Tuple<IList<TSource>, IList<TSource>>(succeeded, failed);
        }
    }
}
