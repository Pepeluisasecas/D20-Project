using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Runtime.Serialization;

[System.Serializable]
public class CoreDictionary<TKey, TValue> : ISerializationCallbackReceiver, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue>, ICollection, IDictionary, IDeserializationCallback, ISerializable
{
    [SerializeField] List<TKey> keys = new List<TKey>();
    [SerializeField] List<TValue> values = new List<TValue>();
    Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

    public void OnAfterDeserialize()
    {
        dictionary.Clear();
        
        var count = Mathf.Min(keys.Count, values.Count);
        for (int i = 0; i < count; i++)
            dictionary.Add(keys[i], values[i]);
    }

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (var kvp in dictionary)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }
    
    public int Count => dictionary.Count;
public bool IsReadOnly => ((ICollection<TKey>)dictionary).IsReadOnly;

public ICollection<TKey> Keys => dictionary.Keys;
public ICollection<TValue> Values => dictionary.Values;

IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => ((IReadOnlyDictionary<TKey, TValue>)dictionary).Keys;
IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => ((IReadOnlyDictionary<TKey, TValue>)dictionary).Values;

public bool IsSynchronized => ((ICollection)dictionary).IsSynchronized;
public object SyncRoot => ((ICollection)dictionary).SyncRoot;

public bool IsFixedSize => ((IDictionary)dictionary).IsFixedSize;
ICollection IDictionary.Keys => ((IDictionary)dictionary).Keys;
ICollection IDictionary.Values => ((IDictionary)dictionary).Values;
public object this[object key] { get => ((IDictionary)dictionary)[key]; set => ((IDictionary)dictionary)[key] = value; }
public TValue this[TKey key] { get => dictionary[key]; set => dictionary[key] = value; }

public void Add(KeyValuePair<TKey, TValue> item) => ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).Add(item);
public void Clear() => dictionary.Clear();
public bool Contains(KeyValuePair<TKey, TValue> item) => ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).Contains(item);
public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).CopyTo(array, arrayIndex);
public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => dictionary.GetEnumerator();
public bool Remove(KeyValuePair<TKey, TValue> item) => ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).Remove(item);
IEnumerator IEnumerable.GetEnumerator() => dictionary.GetEnumerator();

public void Add(TKey key, TValue value) => dictionary.Add(key, value);
public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);
public bool Remove(TKey key) => dictionary.Remove(key);
public bool TryGetValue(TKey key, out TValue value) => dictionary.TryGetValue(key, out value);

public void CopyTo(System.Array array, int index) => ((ICollection)dictionary).CopyTo(array, index);

public void Add(object key, object value) => ((IDictionary)dictionary).Add(key, value);
public bool Contains(object key) => ((IDictionary)dictionary).Contains(key);
IDictionaryEnumerator IDictionary.GetEnumerator() => ((IDictionary)dictionary).GetEnumerator();
public void Remove(object key) => ((IDictionary)dictionary).Remove(key);

public void OnDeserialization(object sender) => dictionary.OnDeserialization(sender);

public void GetObjectData(SerializationInfo info, StreamingContext context) => dictionary.GetObjectData(info, context);
}