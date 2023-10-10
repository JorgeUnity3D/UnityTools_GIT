using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleStorableVar : MonoBehaviour
{
    void Start()
    {
        BoolPref _boolPref = new BoolPref("BoolPrefName", false);
        Debug.Log("[StorableVarExample] Start() -> _boolPref.Value" + _boolPref.Value);
        _boolPref.Value = true;
        Debug.Log("[StorableVarExample] Start() -> _boolPref.Value" + _boolPref.Value);
    }
}
