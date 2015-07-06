using System;
using System.Collections.Generic;

namespace EighthBit.Collection
{
    [Serializable]
    public class PersistNode<TK,TV,TI>
    {
        public TI Key { get; set; }
        public List<PersistNode<TK,TV,TI>> Children { get; set; }
        public List<KeyValuePair<TK, TV>> Values { get; set; }

    }
}
