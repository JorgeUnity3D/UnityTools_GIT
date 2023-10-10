using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DictionaryExtensions
{
    public static void AddOrSet<K, V>(this Dictionary<K, V> dict, K key, V value)
    {
        if (dict.ContainsKey(key))
        {
            dict[key] = value;
        }
        else
        {
            dict.Add(key, value);
        }
    }
}
