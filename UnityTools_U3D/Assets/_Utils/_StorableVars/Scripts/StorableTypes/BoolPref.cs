using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolPref : StorableVar
{
    private bool _value;
    public bool Value
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
    public BoolPref(string varName, bool defaultValue)
    {
        VarName = varName;
        bool storedValue = GetBool();
        if (!Exists /*&& defaultValue != 0*/)
        {
            Value = defaultValue;
        }
        else
        {
            Value = storedValue;
        }
    }
}
