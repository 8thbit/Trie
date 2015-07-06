using System.Collections.Generic;
using EighthBit.Collection.General;

namespace EighthBit.Collection.Numeric
{
    public sealed class UShortIndexBuilder<TK> : INumericIndexBuilder<TK,ushort>
    {
        private  readonly ushort[] _table = {
            10000,
            1000,
            100,
            10,
            1
        };

        public int[] Build(ushort key, int level)
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
            return typeof (TK) == typeof (ushort);
        }

        public ushort Normalize(TK key)
        {
            return ushort.Parse(key.ToString());
        }
    }
}
