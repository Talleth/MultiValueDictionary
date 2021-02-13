using System;
using System.Collections.Generic;

namespace MultiValue
{
    public class Program
    {
        public static void Main(string[] arguments)
        {
            MultiValueDictionary<int, string> multiValueDictionary = new MultiValueDictionary<int, string>();

            multiValueDictionary.Add(1, "Lonnie");
            multiValueDictionary.Add(2, "Joe");
            multiValueDictionary.Add(3, "Fred");
            multiValueDictionary.Add(1, "Jane");

            foreach (KeyValuePair<int, string> keyValuePair in multiValueDictionary)
            {
                string listString = string.Empty;

                Console.WriteLine(keyValuePair.Key + " : " + listString.TrimEnd(','));
            }

            //IReadOnlyCollection<string> collection = multiValueDictionary[1];

            //TestDictionary<int, string> testDictionary = new TestDictionary<int, string>();

            //testDictionary.AddValue(1, "Lonnie");
            //testDictionary.AddValue(2, "Joe");
            //testDictionary.AddValue(3, "Fred");
            //testDictionary.AddValue(1, "Jane");

            //Console.WriteLine(testDictionary.ToString());
        }
    }
}
