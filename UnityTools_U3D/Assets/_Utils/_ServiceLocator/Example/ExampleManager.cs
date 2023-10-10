using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleManager : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Instance.RegisterService(this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.UnregisterService<ExampleManager>();
    }

    public void ExampleMethod()
    {
        Debug.Log("[ExampleManager] ExampleMethod()");
    }
}
