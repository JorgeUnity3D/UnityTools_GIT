using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Pref : StorableVar
{
    private Vector3 _value;
    public Vector3 Value
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
    public Vector3Pref(string varName, Vector3 defaultValue)
    {
        VarName = varName;
        Vector3 storedValue = GetVector3();
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
