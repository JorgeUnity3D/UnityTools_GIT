using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPref : StorableVar
{
    private float _value;
    public float Value
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
    public FloatPref(string varName, float defaultValue)
    {
        VarName = varName;
        float storedValue = GetFloat();
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
