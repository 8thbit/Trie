﻿using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EighthBit.Collection.Numeric
{
    public sealed class SvNumericNode<TK, TV> : NumericNode<TK, TV>
    {
        private readonly ConcurrentDictionary<TK, TV> _values = new  ConcurrentDictionary<TK, TV>();

        protected override bool AddValue(TK key, TV value)
        {
            return _values.TryAdd(key, value);
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

        public SvNumericNode(TrieSettings<TK, TV, int> settings)
            : base(settings)
        {
        }
    }
}