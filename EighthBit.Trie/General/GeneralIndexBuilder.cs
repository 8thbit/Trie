using System.Linq;

namespace EighthBit.Collection.General
{
    public class GeneralIndexBuilder<TK>:IGeneralIndexBuilder<TK,TK>
    {
        public char[] Build(TK key, int level)
        {
            var keyString = key.ToString();
            var len = keyString.Length;
            var size = level < len ? level : level > len ? len : level;
            var indices = keyString.Take(size).ToArray();
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
