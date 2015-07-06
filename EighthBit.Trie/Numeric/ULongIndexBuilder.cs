using System.Collections.Generic;
using EighthBit.Collection.General;

namespace EighthBit.Collection.Numeric
{
    public sealed class ULongIndexBuilder<TK> : INumericIndexBuilder<TK,ulong>
    {
        private  readonly ulong[] _table = {
            10000000000000000000,
            1000000000000000000,
            100000000000000000,
            10000000000000000,
            1000000000000000,
            100000000000000,
            10000000000000,
            1000000000000,
            100000000000,
            10000000000,
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

        public int[] Build(ulong key, int level)
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
            return typeof (TK) == typeof (ulong);
        }

        public ulong Normalize(TK key)
        {
            return ulong.Parse(key.ToString());
        }
    }
}
