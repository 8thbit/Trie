using System.Collections.Generic;

namespace EighthBit.Collection
{
    public interface ITrieNode
    {
        void AppendChild(object key, ITrieNode child);
        void AppendValue(object key,object value);
    }

    public interface ITrieNode<TK, TV, TI> : ITrieValue<TK, TV>,ITrieNode
    {
        ITrieNode<TK, TV, TI> Get(TI[] index, int level);
        bool Add(TK key, TV value, TI[] index, int level);
        IEnumerable<KeyValuePair<TI,ITrieNode<TK, TV, TI>>> Children();
    }
}