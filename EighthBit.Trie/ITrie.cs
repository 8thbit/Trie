using System.Collections.Generic;
using System.IO;

namespace EighthBit.Collection
{

    public interface ITrie<TK, TV>
    {
        ITrieValue<TK, TV> Root { get; }
        void Add(TK key, TV value);
        ITrieValue<TK, TV> Get(TK key);
        IEnumerable<TV> Values(TK key);
        IEnumerable<TV> ExactValues(TK key);
        void Save(Stream stream);
        void Load(Stream stream);
    }
}