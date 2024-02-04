using SistemaDeNumeracao.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNumeracao
{
    internal class DictionaryWrapper<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> internalDictionary = new Dictionary<TKey, TValue>();

        internal void AddItem(TKey key, TValue value)
        {
            internalDictionary[key] = value;
        }

        internal TValue GetItem(TKey key)
        {
            return internalDictionary.TryGetValue(key, out TValue value) ? value : default(TValue);
        }
    }
}
