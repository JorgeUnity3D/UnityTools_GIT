using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BytesPref : StorableVar
{
    private byte[] _value;
    public byte[] Value
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
                //todo: serialize to base64 and json file
            }
        }
    }
    public BytesPref(string varName, byte[] defaultValue)
    {
        VarName = varName;
        byte[] storedValue = GetBytes();
        if (!Exists && defaultValue != null)
        {
            Value = defaultValue;
        }
        else
        {
            Value = storedValue;
        }
    }
}
