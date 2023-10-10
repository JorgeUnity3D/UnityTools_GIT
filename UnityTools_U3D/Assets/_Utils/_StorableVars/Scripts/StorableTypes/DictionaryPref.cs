using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryPref<TKey, TValue> : StorableVar
{
    private Dictionary<TKey, TValue> _value;
    public Dictionary<TKey, TValue> Value
    {
        get { 
            return _value; }
        set
        {
            if (value != _value)
            {
                _value = value;
                SetDictionary(value);
            }
        }
    }
    public DictionaryPref(string varName, Dictionary<TKey, TValue> defaultValue) {
        VarName = varName;
        Dictionary<TKey, TValue> storedValue = GetDictionary<TKey, TValue>();
        if (!Exists && defaultValue != null && defaultValue.Count > 0)
        {
            Value = defaultValue;
        } else
        {
            Value = storedValue;
        }
    }
}
