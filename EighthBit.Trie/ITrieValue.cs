using System.Collections.Generic;

namespace EighthBit.Collection
{
    public interface ITrieValue<TK, TV>
    {
        IEnumerable<KeyValuePair<TK, TV>> Pairs();
        IEnumerable<TK> Keys();
        IEnumerable<TV> Values();
    }
}