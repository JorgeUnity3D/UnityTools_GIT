using System.Collections;
using UnityEngine;

public class LongPref : StorableVar
{
    private long _value;
    public long Value
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
    public LongPref(string varName, long defaultValue)
    {
        VarName = varName;
        long storedValue = GetLong();
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