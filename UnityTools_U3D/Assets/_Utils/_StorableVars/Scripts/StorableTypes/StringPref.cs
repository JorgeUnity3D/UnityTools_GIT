using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPref : StorableVar
{
    private string _value;
    public string Value
    {
        get { 
            return _value; }
        set
        {
            if (value != _value)
            {
                _value = value;
                SetValue(value);
            }
        }
    }
    public StringPref(string varName, string defaultValue) {
        VarName = varName;
        string storedValue = GetString();
        if (!Exists && !string.IsNullOrEmpty(defaultValue))
        {
            Value = defaultValue;
        } else
        {
            Value = storedValue;
        }
    }
}
