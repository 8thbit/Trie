using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace EighthBit.Collection.General
{
    public abstract class GeneralNode<TK, TV, TI> : ITrieNode<TK, TV, TI>
    {
        private readonly ConcurrentDictionary<TI, ITrieNode<TK, TV, TI>> _children =
            new ConcurrentDictionary<TI, ITrieNode<TK, TV, TI>>();

        private readonly TrieSettings<TK, TV, TI> _settings;

        public bool Add(TK key, TV value, TI[] index, int level)
        {
            if (level < index.Length)
            {
                var pos = index[level];
                if (!_children.ContainsKey(pos))
                    _children.TryAdd(pos, _settings.TrieBuilder());

                var node = _children[pos];
                return node.Add(key, value, index, level + 1);
            }

            return AddValue(key, value);
        }

        public ITrieNode<TK, TV, TI> Get(TI[] index, int level)
        {
            if (level < index.Length)
            {
                var pos = index[level];
                ITrieNode<TK, TV, TI> node;
                _children.TryGetValue(pos, out node);
                return node == null ? this : node.Get(index, level + 1);
            }
            return this;
        }

        public IEnumerable<KeyValuePair<TI, ITrieNode<TK, TV, TI>>> Children()
        {
            return _children;
        }

        void ITrieNode.AppendChild(object key, ITrieNode child)
        {
            _children.TryAdd((TI)key, (ITrieNode<TK, TV, TI>)child);
        }

        void ITrieNode.AppendValue(object key, object value)
        {
            AddValue((TK)key, (TV)value);
        }

        protected abstract bool AddValue(TK key, TV value);
        public abstract IEnumerable<KeyValuePair<TK, TV>> Pairs();
        public abstract IEnumerable<TK> Keys();
        public abstract IEnumerable<TV> Values();

        protected GeneralNode(TrieSettings<TK, TV, TI> settings)
        {
            _settings = settings;
        }

    }
}
