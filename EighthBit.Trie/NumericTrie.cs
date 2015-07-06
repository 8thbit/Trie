using EighthBit.Collection.Numeric;

namespace EighthBit.Collection
{
    public sealed class NumericTrie<TK,TV>:CustomTrie<TK,TV,int>
    {
        public NumericTrie() :
            this(new DefaultNumericTrieSettings<TK, TV>())
        {           
        }

        public NumericTrie(TrieSettings<TK, TV, int> settings) : base(settings)
        {
        }
    }
}
