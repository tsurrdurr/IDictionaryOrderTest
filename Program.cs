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
            var classicDict = new Dictionary<string, object>();
            var orderedDict = new OrderedDictionary();
            var sortedDict = new SortedDictionary<string, object>();
            var sortedList = new SortedList();
            var hybridDict = new HybridDictionary();

            string keyStr = "alpha"; 
            string key1Str = "bravo"; 
            string key2Str = "charlie"; 
            string key3Str = "foxtrot"; 

            var keysUsed = new string[] { keyStr, key1Str, key2Str, key3Str };
            var bagOfDicts = new IDictionary[] { hashTable, classicDict, orderedDict, sortedDict, sortedList, hybridDict };

            addToAllIDictionaries(bagOfDicts, keyStr, "hello");
            addToAllIDictionaries(bagOfDicts, key1Str, new object());
            addToAllIDictionaries(bagOfDicts, key3Str, true);
            addToAllIDictionaries(bagOfDicts, key2Str, 123);

            int index = 0;
            Console.WriteLine("Iterating through keys aplha to foxtrot");
            foreach(var key in keysUsed)
            {
                foreach(IDictionary dictionaryItem in bagOfDicts)
                {
                    Console.WriteLine(formOutput(dictionaryItem, key, index));
                }
                index++;
            }

            Console.Read();
        }

        static string formOutput(IDictionary dictionary, string key, int index)
        {
            var valueType = dictionary[key].GetType().ToString();
            var keyAtIndex = getKeyAtIndex(dictionary, index);
            var dictType = dictionary.GetType();
            return $@"Value type: {valueType}, dict.Keys[{index}]: {keyAtIndex}, Dict key: {key}, Dict type: {dictType}";
        }

        static void addToAllIDictionaries(IDictionary[] dicts, string key, object value)
        {
            foreach (var d in dicts) { d.Add(key, value); }
        }

        static string getKeyAtIndex(IDictionary dictObj, int index) =>	dictObj.Keys.OfType<string>().ElementAt(index);

    }
}
