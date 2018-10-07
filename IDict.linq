<Query Kind="Statements">
  <Namespace>System.Collections</Namespace>
  <Namespace>System.Collections.Specialized</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
</Query>

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

int n = 0;
Console.WriteLine("Iterating through keys list");
foreach(var key in keysUsed)
{
	foreach(IDictionary dictTypeItem in bagOfDicts)
	{
		Console.WriteLine(formOutput(dictTypeItem, key));
	}
	n++;
}

string formOutput(IDictionary dictRepresentation, string key)
{
	var valueType = dictRepresentation[key].GetType().ToString();
	var keyAtIndex = getKeyAtIndex(dictRepresentation, n);
	var dictType = dictRepresentation.GetType();
	return $@"Value type: {valueType}, dict.Keys[{n}]: {keyAtIndex}, Dict key: {key}, Dict type: {dictType}";
}

void addToAll(IDictionary[] dicts, string key, object value)
{
	foreach (var d in dicts) { d.Add(key, value); }
}

string getKeyAtIndex(IDictionary dictObj, int index) =>	dictObj.Keys.OfType<object>().ElementAt(index).ToString();
