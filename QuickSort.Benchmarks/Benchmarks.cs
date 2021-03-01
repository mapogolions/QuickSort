namespace QuickSort.Benchmarks
{
    using System;
    using System.Collections.Generic;
    using QuickSort.Algorithm;
    using BenchmarkDotNet.Attributes;
    using System.Linq;

    [MinColumn]
    [MaxColumn]
    public class Benchmarks
    {
        private readonly IList<int> _dataset = RandomNumbersRange(-5_000_000, 5_000_000, 10_000_000).ToList();

        [Benchmark]
        public void SequentialQuickSort() => QuickSort.Sort(_dataset);

        [Benchmark]
        public void ParallelQuickSort() => QuickSort.ParallelSort(_dataset, RecursiveDepth(Environment.ProcessorCount));

        private static int[] RandomNumbersRange(int min, int max, int size)
        {
            var random = new Random();
            var bag = new int[size];
            for (var i = 0; i < size; i++)
            {
                bag[i] = random.Next(min, max);
            }
            return bag;
        }

        private int RecursiveDepth(int processorCount) => (int) (Math.Log2(processorCount) + 4);
    }
}
