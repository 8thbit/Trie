namespace EighthBit.Collection.Numeric
{
    public class DefaultNumericTrieSettings<TK,TV>:TrieSettings<TK,TV,int>
    {
        public DefaultNumericTrieSettings()
        {
            IndexBuilder=new NumericIndexBuilder<TK>();
            TrieBuilder=()=>new MvNumericNode<TK, TV>(this);
            Serializer=new DefaultSerializer<TK, TV, int>();
        } 
    }
}
