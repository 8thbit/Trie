using System;
using EighthBit.Collection.General;

namespace EighthBit.Collection.Numeric
{
    public class NumericIndexBuilder<TK>:INumericIndexBuilder<TK,TK>
    {
        public int[] Build(TK key, int level)
        {
            var keyString = key.ToString();
            var len = keyString.Length;
            var size = level < len ? level : level > len ? len : level;
            var indices = new int[size];

            for (var i = 0; i < size; i++)
            {
                var c = keyString[i];
                if (char.IsDigit(c))
                {
                    indices[i] = c - 0x30;
                    continue;
                }
                switch (c)
                {
                    case '-':
                        indices[i] = NumericIndices.MinusPosition;
                        continue;
                    case '+':
                        indices[i] = NumericIndices.PlusPosition;
                        continue;
                    case '.':
                        indices[i] = NumericIndices.DotPosition;
                        continue;
                    case 'E':
                        indices[i] = NumericIndices.ExponentPosition;
                        continue;
                    default:
                        throw new InvalidOperationException("input is not supported.");
                }
            }

            return indices;
        }

        public bool ShouldNormalize()
        {
            return false;
        }

        public TK Normalize(TK key)
        {
            return key;
        }
    }
}
