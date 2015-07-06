using System.Collections.Generic;
using EighthBit.Collection.General;

namespace EighthBit.Collection.Numeric
{
    public sealed class ByteIndexBuilder<TK> : INumericIndexBuilder<TK,byte>
    {
        private readonly byte[] _table = {
            100,
            10,
            1
        };

        public int[] Build(byte key, int level)
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
            return typeof (TK) == typeof (byte);
        }

        public byte Normalize(TK key)
        {
            return byte.Parse(key.ToString());
        }
    }
}
