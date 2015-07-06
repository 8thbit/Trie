using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EighthBit.Collection
{
    public class DefaultSerializer<TK,TV,TI>:ISerializer<TK,TV,TI>
    {
        public void Save(Stream stream, PersistNode<TK, TV, TI> node,TrieSettings<TK,TV,TI> settings )
        {
            var bf=new BinaryFormatter();
            bf.Serialize(stream,node);
        }

        public PersistNode<TK, TV, TI> Load(Stream stream, TrieSettings<TK, TV, TI> settings)
        {
            var bf=new BinaryFormatter();
            var obj = bf.Deserialize(stream);
            return obj as PersistNode<TK, TV, TI>;
        }
    }
}
