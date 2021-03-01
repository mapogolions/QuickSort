namespace QuickSort.Tests
{
    using Xunit;
    using QuickSort.Algorithm;
    using System;
    using System.Collections.Generic;

    public class EnumerableExtensionsTests
    {
        [Fact]
        public void Partition_Numbers_SplitListOntoToHalf()
        {
            var source = new List<int> { -10, -2, 3, 30, -1 };
            var (succeeded, failed) = source.Partition(x => x > 0);

            Assert.Equal(new List<int> { -10, -2, -1 }, failed);
            Assert.Equal(new List<int> { 3, 30 }, succeeded);
        }

        [Fact]
        public void Partition_PositiveCollection_ReturnsEmptyFailedList()
        {
            var source = new List<int> { 1, 10, 3, 4 };
            var (succeeded, failed) = source.Partition(x => x > 0);

            Assert.Equal(source, succeeded);
            Assert.Empty(failed);
        }

        [Fact]
        public void Partition_EmptyList_ReturnsTupleWithEmptyItems()
        {
            var source = new List<int>();
            var (succeeded, failed) = source.Partition(x => x > 0);

            Assert.Empty(succeeded);
            Assert.Empty(failed);
        }
    }
}
