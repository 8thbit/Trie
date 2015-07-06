namespace EighthBit.Collection.General
{
    public class DefaultGeneralTrieSettings<TK,TV>:TrieSettings<TK,TV,char>
    {
        public DefaultGeneralTrieSettings()
        {
            IndexBuilder=new GeneralIndexBuilder<TK>();
            TrieBuilder=()=>new MvGeneralNode<TK, TV, char>(this);
            Serializer = new DefaultSerializer<TK, TV, char>();
        } 
    }
}
