using System;
using System.Collections.Generic;
using System.Text;

namespace MultiValue
{
    public class TestDictionary<Tkey, TValue> : Dictionary<Tkey, List<TValue>>
    {
        public void AddValue(Tkey key, TValue value)
        {
            if (this.ContainsKey(key))
                this[key].Add(value);
            else
                this.Add(key, new List<TValue>() { value });
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (KeyValuePair<Tkey, List<TValue>> value in this)
            {
                result += value.Key + " : ";

                foreach (TValue listItem in value.Value)
                    result += listItem + ",";

                result = result.TrimEnd(',');
                result += Environment.NewLine;
            }

            return result.TrimEnd('\n').TrimEnd('\r');
        }
    }
}
