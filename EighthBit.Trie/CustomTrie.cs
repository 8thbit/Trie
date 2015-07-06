using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EighthBit.Collection
{
    public class CustomTrie<TK,TV,TI> : ITrie<TK, TV>
    {
        private readonly TrieSettings<TK, TV, TI> _settings; 
        private ITrieNode<TK, TV,TI> _root;
 
        private readonly bool _needNormalizing;
        private readonly int _maxLevel;

        public ITrieValue<TK, TV> Root { get { return _root; } }
 
        public void Add(TK key, TV value)
        {
            var finalKey = _needNormalizing ? _settings.IndexBuilder.Normalize(key) : key;
            var index = _settings.IndexBuilder.Build(finalKey, _maxLevel);
            _root.Add(key,value, index, 0);
        }

        public ITrieValue<TK, TV> Get(TK key)
        {
            var finalKey = _needNormalizing ? _settings.IndexBuilder.Normalize(key) : key;
            var index = _settings.IndexBuilder.Build(finalKey, _maxLevel);
            var trie = _root.Get(index, 0);
            return _root.Equals(trie) ? null : trie;
        }

        public IEnumerable<TV> Values(TK key)
        {
            var trie= Get(key);
            return trie == _root ? null : trie.Values();
        }

        public IEnumerable<TV> ExactValues(TK key)
        {
            var trie = Get(key);
            return trie == _root ? null : trie.Pairs().Where(p => p.Key.Equals(key)).Select(p => p.Value);
        }


        public CustomTrie(TrieSettings<TK,TV,TI> settings )
        {
            _settings = settings;
            _root = _settings.TrieBuilder();
            _needNormalizing = _settings.IndexBuilder.ShouldNormalize();
            _maxLevel = settings.Level;
        }

        public void Save(Stream stream)
        {
            var persister=new Persister<TK,TV,TI>{Settings = _settings};
            var node = persister.ToPersistable(_root);
            _settings.Serializer.Save(stream,node,_settings);
        }

        public void Load(Stream stream)
        {
            var node = _settings.Serializer.Load(stream, _settings);
            var persister = new Persister<TK, TV, TI>{Settings=_settings};
            var root = persister.ToTrieNode(node);
            _root = root;
        }
    }
}
