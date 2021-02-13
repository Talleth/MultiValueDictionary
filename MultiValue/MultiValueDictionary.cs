using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MultiValue
{
    public class MultiValueDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>

    {
        private Dictionary<TKey, List<TValue>> dictionary;

        public MultiValueDictionary()
        {
            this.dictionary = new Dictionary<TKey, List<TValue>>();
        }

        public void Remove(TKey key)
        {
            this.dictionary.Remove(key);
        }

        public void Add(TKey key, TValue value)
        {
            if (this.dictionary.ContainsKey(key))
                this.dictionary[key].Add(value);
            else
                this.dictionary.Add(key, new List<TValue>() { value });
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var list in this.dictionary)
                foreach (TValue value in list.Value)
                    yield return new KeyValuePair<TKey, TValue>(list.Key, value);
        }
         
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IReadOnlyCollection<TValue> this[TKey key]
        {
            get { return this.dictionary[key]; }
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (KeyValuePair<TKey, List<TValue>> keyValuePair in this.dictionary)
            {
                result += keyValuePair.Key + " : ";

                foreach (TValue listItem in keyValuePair.Value)
                    result += listItem + ",";

                result = result.TrimEnd(',');
                result += Environment.NewLine;
            }

            return result.TrimEnd('\n').TrimEnd('\r');
        }
    }
}