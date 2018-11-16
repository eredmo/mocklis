// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecordPropertyStep.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Record
{
    #region Using Directives

    using System.Collections;
    using System.Collections.Generic;
    using Mocklis.Core;

    #endregion

    public abstract class RecordPropertyStep<TValue, TRecord> : MedialPropertyStep<TValue>, IReadOnlyList<TRecord>
    {
        private readonly object _lockObject = new object();
        private readonly List<TRecord> _ledger = new List<TRecord>();

        protected void Add(TRecord record)
        {
            lock (_lockObject)
            {
                _ledger.Add(record);
            }
        }

        public IEnumerator<TRecord> GetEnumerator() => _ledger.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _ledger.GetEnumerator();

        public int Count => _ledger.Count;

        public TRecord this[int index] => _ledger[index];
    }
}