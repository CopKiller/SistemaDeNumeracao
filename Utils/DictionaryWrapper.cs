using SistemaDeNumeracao.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNumeracao.Utils
{
    internal class DictionaryWrapper<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> internalDictionary = new();

        internal void AddItem(TKey key, TValue value)
        {
            internalDictionary[key] = value;
        }

        internal TValue? GetItem(TKey key)
        {
            return internalDictionary.TryGetValue(key, out TValue value) ? value : default;
        }

        internal Dictionary<TKey, TValue> GetItems()
        {
            return internalDictionary;
        }

        //internal void UpdateValuesDifferentFrom(TKey keyToCheck, TValue newValue, Type valueType)
        //{
        //    internalDictionary
        //        .Where(x => !EqualityComparer<TKey>.Default.Equals(x.Key, keyToCheck) && x.Value.GetType() == valueType)
        //        .ToList()
        //        .ForEach(x => internalDictionary[x.Key] = newValue);
        //}
    }
}
