using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntPref : StorableVar
{
    private int _value;
    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (value != _value)
            {
                _value = value;
                SetValue(value);
            }
        }
    }
    public IntPref(string varName, int defaultValue)
    {
        VarName = varName;
        int storedValue = GetInt();
        if (!Exists && defaultValue != 0)
        {
            Value = defaultValue;
        }
        else
        {
            Value = storedValue;
        }
    }
}
