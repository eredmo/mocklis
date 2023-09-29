// <auto-generated />

#nullable enable

namespace Test
{
    partial class TestClass
    {
        public global::Mocklis.Core.FuncMethodMock<TKey, bool> ContainsKey { get; }

        bool global::System.Collections.Generic.IDictionary<TKey, TValue>.ContainsKey(TKey key) => ContainsKey.Call(key);

        public global::Mocklis.Core.ActionMethodMock<(TKey key, TValue value)> Add { get; }

        void global::System.Collections.Generic.IDictionary<TKey, TValue>.Add(TKey key, TValue value) => Add.Call((key, value));

        public global::Mocklis.Core.FuncMethodMock<TKey, bool> Remove { get; }

        bool global::System.Collections.Generic.IDictionary<TKey, TValue>.Remove(TKey key) => Remove.Call(key);

        public global::Mocklis.Core.FuncMethodMock<TKey, (bool returnValue, TValue value)> TryGetValue { get; }

        bool global::System.Collections.Generic.IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
        {
            var tmp = TryGetValue.Call(key);
            value = tmp.value;
            return tmp.returnValue;
        }

        // Adding line for Property Based Indexer Mock

        // Adding line for Property Based Property Mock

        // Adding line for Property Based Property Mock

        public global::Mocklis.Core.ActionMethodMock<global::System.Collections.Generic.KeyValuePair<TKey, TValue>> Add0 { get; }

        void global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<TKey, TValue>>.Add(global::System.Collections.Generic.KeyValuePair<TKey, TValue> item) => Add0.Call(item);

        public global::Mocklis.Core.ActionMethodMock Clear { get; }

        void global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<TKey, TValue>>.Clear() => Clear.Call();

        public global::Mocklis.Core.FuncMethodMock<global::System.Collections.Generic.KeyValuePair<TKey, TValue>, bool> Contains { get; }

        bool global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<TKey, TValue>>.Contains(global::System.Collections.Generic.KeyValuePair<TKey, TValue> item) => Contains.Call(item);

        public global::Mocklis.Core.ActionMethodMock<(global::System.Collections.Generic.KeyValuePair<TKey, TValue>[] array, int arrayIndex)> CopyTo { get; }

        void global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<TKey, TValue>>.CopyTo(global::System.Collections.Generic.KeyValuePair<TKey, TValue>[] array, int arrayIndex) => CopyTo.Call((array, arrayIndex));

        public global::Mocklis.Core.FuncMethodMock<global::System.Collections.Generic.KeyValuePair<TKey, TValue>, bool> Remove0 { get; }

        bool global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<TKey, TValue>>.Remove(global::System.Collections.Generic.KeyValuePair<TKey, TValue> item) => Remove0.Call(item);

        // Adding line for Property Based Property Mock

        // Adding line for Property Based Property Mock

        public global::Mocklis.Core.FuncMethodMock<global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<TKey, TValue>>> GetEnumerator { get; }

        global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<TKey, TValue>> global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<TKey, TValue>>.GetEnumerator() => GetEnumerator.Call();

        public global::Mocklis.Core.FuncMethodMock<global::System.Collections.IEnumerator> GetEnumerator0 { get; }

        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() => GetEnumerator0.Call();

        protected TestClass() : base()
        {
            this.ContainsKey = new global::Mocklis.Core.FuncMethodMock<TKey, bool>(this, "TestClass", "IDictionary", "ContainsKey", "ContainsKey", global::Mocklis.Core.Strictness.Lenient);
            this.Add = new global::Mocklis.Core.ActionMethodMock<(TKey key, TValue value)>(this, "TestClass", "IDictionary", "Add", "Add", global::Mocklis.Core.Strictness.Lenient);
            this.Remove = new global::Mocklis.Core.FuncMethodMock<TKey, bool>(this, "TestClass", "IDictionary", "Remove", "Remove", global::Mocklis.Core.Strictness.Lenient);
            this.TryGetValue = new global::Mocklis.Core.FuncMethodMock<TKey, (bool returnValue, TValue value)>(this, "TestClass", "IDictionary", "TryGetValue", "TryGetValue", global::Mocklis.Core.Strictness.Lenient);
            this.Add0 = new global::Mocklis.Core.ActionMethodMock<global::System.Collections.Generic.KeyValuePair<TKey, TValue>>(this, "TestClass", "ICollection", "Add", "Add0", global::Mocklis.Core.Strictness.Lenient);
            this.Clear = new global::Mocklis.Core.ActionMethodMock(this, "TestClass", "ICollection", "Clear", "Clear", global::Mocklis.Core.Strictness.Lenient);
            this.Contains = new global::Mocklis.Core.FuncMethodMock<global::System.Collections.Generic.KeyValuePair<TKey, TValue>, bool>(this, "TestClass", "ICollection", "Contains", "Contains", global::Mocklis.Core.Strictness.Lenient);
            this.CopyTo = new global::Mocklis.Core.ActionMethodMock<(global::System.Collections.Generic.KeyValuePair<TKey, TValue>[] array, int arrayIndex)>(this, "TestClass", "ICollection", "CopyTo", "CopyTo", global::Mocklis.Core.Strictness.Lenient);
            this.Remove0 = new global::Mocklis.Core.FuncMethodMock<global::System.Collections.Generic.KeyValuePair<TKey, TValue>, bool>(this, "TestClass", "ICollection", "Remove", "Remove0", global::Mocklis.Core.Strictness.Lenient);
            this.GetEnumerator = new global::Mocklis.Core.FuncMethodMock<global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<TKey, TValue>>>(this, "TestClass", "IEnumerable", "GetEnumerator", "GetEnumerator", global::Mocklis.Core.Strictness.Lenient);
            this.GetEnumerator0 = new global::Mocklis.Core.FuncMethodMock<global::System.Collections.IEnumerator>(this, "TestClass", "IEnumerable", "GetEnumerator", "GetEnumerator0", global::Mocklis.Core.Strictness.Lenient);
        }
    }
}
