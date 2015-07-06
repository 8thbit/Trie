using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace EighthBit.Collection.General
{
    public sealed class MvGeneralNode<TK, TV,TI> : GeneralNode<TK, TV,TI>
    {
        private readonly ConcurrentBag<KeyValuePair<TK, TV>> _values = new ConcurrentBag<KeyValuePair<TK, TV>>();

        protected override bool AddValue(TK key, TV value)
        {
            _values.Add(new KeyValuePair<TK, TV>(key, value));
            return true;
        }

        public override IEnumerable<KeyValuePair<TK, TV>> Pairs()
        {
            return _values;
        }

        public override IEnumerable<TK> Keys()
        {
            return _values.Select(p => p.Key).Distinct();
        }

        public override IEnumerable<TV> Values()
        {
            return _values.Select(p => p.Value).Distinct();
        }

        public MvGeneralNode(TrieSettings<TK, TV, TI> settings)
            : base(settings)
        {
        }
    }
}
