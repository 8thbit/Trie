using System.Collections.Generic;
using EighthBit.Collection.General;

namespace EighthBit.Collection.Numeric
{
    public sealed class UIntIndexBuilder<TK> : INumericIndexBuilder<TK,uint>
    {
        private readonly uint[] _table = {
            1000000000,
            100000000,
            10000000,
            1000000,
            100000,
            10000,
            1000,
            100,
            10,
            1
        };

        public int[] Build(uint key, int level)
        {
            var indices = new List<int>();
            var started = false;

            for (var pos = 0; pos < _table.Length; pos++)
            {
                if (indices.Count == level)
                    return indices.ToArray();

                var count = 0;
                while (key >= _table[pos])
                {
                    started = true;
                    count++;
                    key -= _table[pos];
                }

                if (!started)
                    continue;
                indices.Add(count);
            }
            return indices.ToArray();
        }

        public bool ShouldNormalize()
        {
            return typeof (TK) == typeof (uint);
        }

        public uint Normalize(TK key)
        {
            return uint.Parse(key.ToString());
        }
    }
}
