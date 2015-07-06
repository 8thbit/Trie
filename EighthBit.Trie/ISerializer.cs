using System.IO;

namespace EighthBit.Collection
{
    public interface ISerializer<TK,TV,TI>
    {
        void Save(Stream stream, PersistNode<TK, TV, TI> node, TrieSettings<TK, TV, TI> settings);
        PersistNode<TK, TV, TI> Load(Stream stream, TrieSettings<TK, TV, TI> settings);
    }
}
