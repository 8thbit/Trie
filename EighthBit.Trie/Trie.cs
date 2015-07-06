using EighthBit.Collection.General;

namespace EighthBit.Collection
{
    public sealed class Trie<TK, TV> : CustomTrie<TK, TV, char>
    {
        public Trie() :
            this(new DefaultGeneralTrieSettings<TK, TV>())
        {
        }

        public Trie(TrieSettings<TK, TV, char> settings)
            : base(settings)
        {
        }
    }
}
