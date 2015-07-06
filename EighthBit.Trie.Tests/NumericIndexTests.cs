using EighthBit.Collection.Numeric;
using Xunit;

namespace EighthBit.Trie.Tests
{
    public class NumericIndexTests
    {
        [Fact]
        public void DefaultIndexBuilderInt32()
        {
            var number = 1234;

            var builder = new NumericIndexBuilder<int>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { 1 }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { 1, 2, 3 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { 1, 2, 3, 4 }, level10Index);
        }

        [Fact]
        public void DefaultIndexBuilderNegativeInt32()
        {
            var number = -1234;

            var builder = new NumericIndexBuilder<int>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] {}, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] {NumericIndices.MinusPosition}, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] {NumericIndices.MinusPosition, 1, 2}, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] {NumericIndices.MinusPosition, 1, 2, 3, 4}, level10Index);
        }

        [Fact]
        public void DefaultIndexBuilderUInt32()
        {
            var number = 1234U;

            var builder = new NumericIndexBuilder<uint>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] {}, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] {1}, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] {1, 2, 3}, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] {1, 2, 3, 4}, level10Index);
        }

        [Fact]
        public void IndexBuilderUInt32()
        {
            var number = 1234U;

            var builder = new UIntIndexBuilder<uint>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { 1 }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { 1, 2, 3 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { 1, 2, 3, 4 }, level10Index);
        }

        [Fact]
        public void DefaultIndexBuilderInt16()
        {
            var number = (short)1234;

            var builder = new NumericIndexBuilder<short>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { 1 }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { 1, 2, 3 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { 1, 2, 3, 4 }, level10Index);
        }

        [Fact]
        public void DefaultIndexBuilderNegativeInt16()
        {
            var number = (short)-1234;

            var builder = new NumericIndexBuilder<short>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { NumericIndices.MinusPosition }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { NumericIndices.MinusPosition, 1, 2 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { NumericIndices.MinusPosition, 1, 2, 3, 4 }, level10Index);
        }

        [Fact]
        public void DefaultIndexBuilderUInt16()
        {
            var number = (ushort)1234U;

            var builder = new NumericIndexBuilder<ushort>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { 1 }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { 1, 2, 3 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { 1, 2, 3, 4 }, level10Index);
        }

        [Fact]
        public void IndexBuilderUInt16()
        {
            var number = (ushort)1234U;

            var builder = new UShortIndexBuilder<ushort>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { 1 }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { 1, 2, 3 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { 1, 2, 3, 4 }, level10Index);
        }

        [Fact]
        public void DefaultIndexBuilderByte()
        {
            var number = (byte)123;

            var builder = new NumericIndexBuilder<byte>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { 1 }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { 1, 2, 3 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { 1, 2, 3 }, level10Index);
        }

        [Fact]
        public void DefaultIndexBuilderSByte()
        {
            var number = (sbyte)123;

            var builder = new NumericIndexBuilder<sbyte>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { 1 }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { 1, 2, 3 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { 1, 2, 3 }, level10Index);
        }

        [Fact]
        public void DefaultIndexBuilderNegativeSByte()
        {
            var number = (sbyte)-123;

            var builder = new NumericIndexBuilder<sbyte>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { NumericIndices.MinusPosition }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { NumericIndices.MinusPosition, 1, 2 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { NumericIndices.MinusPosition, 1, 2, 3 }, level10Index);
        }

        [Fact]
        public void IndexBuilderByte()
        {
            var number = (byte)123;

            var builder = new ByteIndexBuilder<byte>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { 1 }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { 1, 2, 3 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { 1, 2, 3 }, level10Index);
        }
        [Fact]
        public void DefaultIndexBuilderNegativeLong()
        {
            var number = -12345678901L;

            var builder = new NumericIndexBuilder<long>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] {}, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] {NumericIndices.MinusPosition}, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] {NumericIndices.MinusPosition, 1, 2}, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] {NumericIndices.MinusPosition, 1, 2, 3, 4, 5, 6, 7, 8, 9}, level10Index);
        }

        [Fact]
        public void DefaultIndexBuilderLong()
        {
            var number = 12345678901L;

            var builder = new NumericIndexBuilder<long>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { 1 }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { 1, 2, 3 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, level10Index);
        }

        [Fact]
        public void DefaultIndexBuilderULong()
        {
            var number = 12345678901UL;

            var builder = new ULongIndexBuilder<ulong>();

            var level0Index = builder.Build(number, 0);
            Assert.Equal(new int[] { }, level0Index);

            var level1Index = builder.Build(number, 1);
            Assert.Equal(new[] { 1 }, level1Index);

            var level3Index = builder.Build(number, 3);
            Assert.Equal(new[] { 1, 2, 3 }, level3Index);

            var level10Index = builder.Build(number, 10);
            Assert.Equal(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, level10Index);
        }
    }
}
