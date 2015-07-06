using System.Linq;

namespace EighthBit.Collection
{
    public class Persister<TK,TV,TI>
    {
        public TrieSettings<TK,TV,TI> Settings { get; set; }

        public PersistNode<TK,TV,TI> ToPersistable(ITrieNode<TK,TV,TI> node)
        {
            var persistable = new PersistNode<TK,TV,TI>
            {
                Children = node.Children().Select(p =>
                {
                    var c = ToPersistable(p.Value);
                    c.Key = p.Key;
                    return c;
                }).ToList(),
                Values = node.Pairs().ToList()
            };

            return persistable;
        }

        public ITrieNode<TK,TV,TI> ToTrieNode(PersistNode<TK,TV,TI> node)
        {
            var trie = Settings.TrieBuilder();
            foreach (var v in node.Values)
                trie.AppendValue(v.Key, v.Value);

            foreach (var c in node.Children)
            {
                var child = ToTrieNode(c);
                trie.AppendChild(c.Key, child);
            }

            return trie;
        }
    }
}
