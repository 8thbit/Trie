using System;

namespace EighthBit.Collection
{
    public class TrieSettings<TK,TV,TI>
    {
        public IIndexBuilder<TK, TK, TI> IndexBuilder { get; set; }
        public Func<ITrieNode<TK, TV, TI>> TrieBuilder { get; set; }
        public ISerializer<TK, TV, TI> Serializer { get; set; }

        public int Level { get; set; }

        public TrieSettings()
        {
            Level = int.MaxValue;
        } 
    }
}
