using System.Collections.Generic;
using System.Linq;

namespace EighthBit.Collection.Numeric
{
    public abstract class NumericNode<TK, TV> : INumericTrieNode<TK, TV>
    {
        private readonly ITrieNode<TK, TV, int>[] _children = new ITrieNode<TK, TV, int>[14]; //2 last ones  are . ,-,+,E
        private readonly TrieSettings<TK, TV, int> _settings;
 
        public bool Add(TK key, TV value, int[] index, int level)
        {
            if (level < index.Length)
            {
                var pos = index[level];
                if (_children[pos] == null)
                    _children[pos] = _settings.TrieBuilder();

                var node = _children[pos];
                return node.Add(key, value, index, level + 1);
            }

            return AddValue(key, value);
        }

        public ITrieNode<TK, TV, int> Get(int[] index, int level)
        {
            if (level < index.Length)
            {
                var pos = index[level];
                var node = _children[pos];
                return node == null ? this : node.Get(index, level + 1);
            }
            return this;
        }

        protected abstract bool AddValue(TK key, TV value);
        public abstract IEnumerable<KeyValuePair<TK, TV>> Pairs();
        public abstract IEnumerable<TK> Keys();
        public abstract IEnumerable<TV> Values();

        protected NumericNode (TrieSettings<TK,TV,int> settings )
        {
            _settings = settings;
        }

        void ITrieNode.AppendChild(object key, ITrieNode child)
        {
            _children[(int)key] = (INumericTrieNode<TK,TV>)child;
        }

        void ITrieNode.AppendValue(object key, object value)
        {
            AddValue((TK)key, (TV)value);
        }

        public IEnumerable<KeyValuePair<int, ITrieNode<TK, TV, int>>> Children()
        {
            return
                _children.Select((t, i) => new KeyValuePair<int, ITrieNode<TK, TV, int>>(i, t))
                    .Where(p => p.Value != null)
                    .ToList();
        }
    }
}
