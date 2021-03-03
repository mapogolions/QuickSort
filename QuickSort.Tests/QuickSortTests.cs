namespace QuickSort.Tests
{
    using Xunit;
    using QuickSort.Algorithm;
    using System.Collections.Generic;
    using System;

    public class QuickSortTests
    {
         [Fact]
        public void ParallelQuickSort_NonEmptyList_ReturnsNewSortedList()
        {
            var source = new List<int> { -1, 2, -20, 0, 6 };
            var actual = QuickSort.ParallelSort(source, Environment.ProcessorCount);

            Assert.False(ReferenceEquals(source, actual));
            Assert.Equal(new List<int> { -20, -1, 0, 2, 6 }, actual);
        }

        [Fact]
        public void ParallelQuickSort_OneElementList_ReturnsNewListWithOneElement()
        {
            var source = new List<int> { 1 };
            var actual = QuickSort.ParallelSort(source, Environment.ProcessorCount);

            Assert.False(ReferenceEquals(source, actual));
            Assert.Equal(source, actual);
        }

        [Fact]
        public void ParallelQuickSort_EmptyList_ReturnsNewEmptyList()
        {
            var source = new List<int>();
            var actual = QuickSort.ParallelSort(source, Environment.ProcessorCount);

            Assert.False(ReferenceEquals(source, actual));
            Assert.Empty(actual);
        }

        [Fact]
        public void SequentialQuickSort_NonEmptyList_ReturnsNewSortedList()
        {
            var source = new List<int> { -1, 2, -20, 0, 6 };
            var actual = QuickSort.Sort(source);

            Assert.False(ReferenceEquals(source, actual));
            Assert.Equal(new List<int> { -20, -1, 0, 2, 6 }, actual);
        }

        [Fact]
        public void SequentialQuickSort_OneElementList_ReturnsNewListWithOneElement()
        {
            var source = new List<int> { 1 };
            var actual = QuickSort.Sort(source);

            Assert.False(ReferenceEquals(source, actual));
            Assert.Equal(source, actual);
        }

        [Fact]
        public void SequentialQuickSort_EmptyList_ReturnsNewEmptyList()
        {
            var source = new List<int>();
            var actual = QuickSort.Sort(source);

            Assert.False(ReferenceEquals(source, actual));
            Assert.Empty(actual);
        }
    }
}
