using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Linq;

namespace IDictionaryOrderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new Hashtable();
            var dict = new Dictionary<string, object>();
            var ordered = new OrderedDictionary();
            var sortedDict = new SortedDictionary<string, object>();
            var sortedList = new SortedList();
            var hybridDict = new HybridDictionary();

            string keyStr = "alpha"; string key1Str = "bravo"; string key2Str = "charlie"; string key3Str = "foxtrot"; 
            var keysUsed = new string[] { keyStr, key1Str, key2Str, key3Str };
            var bagOfDicts = new IDictionary[] { hashTable, dict, ordered, sortedDict, sortedList, hybridDict };

            addToAll(bagOfDicts, keyStr, "hello");
            addToAll(bagOfDicts, key1Str, new object());
            addToAll(bagOfDicts, key3Str, true);
            addToAll(bagOfDicts, key2Str, 123);

            int index = 0;
            Console.WriteLine("Iterating through keys list");
            foreach(var key in keysUsed)
            {
                foreach(IDictionary dictTypeItem in bagOfDicts)
                {
                    Console.WriteLine(formOutput(dictTypeItem, key, index));
                }
                index++;
            }

            Console.Read();
        }


        static string formOutput(IDictionary dictRepresentation, string key, int index)
        {
            var valueType = dictRepresentation[key].GetType().ToString();
            var keyAtIndex = getKeyAtIndex(dictRepresentation, index);
            var dictType = dictRepresentation.GetType();
            return $@"Value type: {valueType}, dict.Keys[{index}]: {keyAtIndex}, Dict key: {key}, Dict type: {dictType}";
        }

        static void addToAll(IDictionary[] dicts, string key, object value)
        {
            foreach (var d in dicts) { d.Add(key, value); }
        }

        static string getKeyAtIndex(IDictionary dictObj, int index) =>	dictObj.Keys.OfType<object>().ElementAt(index).ToString();

    }
}
