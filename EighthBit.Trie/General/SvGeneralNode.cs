using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EighthBit.Collection.General
{
    public sealed class SvGeneralNode<TK, TV,TI> : GeneralNode<TK, TV,TI>
    {
        private readonly Dictionary<TK, TV> _values = new Dictionary<TK, TV>();

        protected override bool AddValue(TK key, TV value)
        {
            _values.Add(key, value);
            return true;
        }

        public override IEnumerable<KeyValuePair<TK, TV>> Pairs()
        {
            return _values;
        }

        public override IEnumerable<TK> Keys()
        {
            return _values.Keys;
        }

        public override IEnumerable<TV> Values()
        {
            return _values.Values;
        }

        public SvGeneralNode(TrieSettings<TK, TV, TI> settings)
            : base(settings)
        {
        }
    }
}
