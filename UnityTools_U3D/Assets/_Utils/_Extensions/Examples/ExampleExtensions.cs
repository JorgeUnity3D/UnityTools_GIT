using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleExtensions : MonoBehaviour
{
    private void Start()
    {
        string exampleString = "example";
        Debug.Log("[ExampleExtensions] Start() -> exampleString: " + exampleString);
        exampleString = exampleString.FirstCharToUpper();
        Debug.Log("[ExampleExtensions] Start() -> exampleString: " + exampleString);

        Transform grandChild = transform.FindDeepChild("ExampleGrandchild");
        Debug.Log("[ExampleExtensions] Start() -> grandChild : " + grandChild.name);

        Debug.Log("[ExampleExtensions] Start() -> gameObject layer : " + gameObject.layer);
        Debug.Log("[ExampleExtensions] Start() -> grandChild layer : " + grandChild.gameObject.layer);
        gameObject.SetLayer(2, true);
        Debug.Log("[ExampleExtensions] Start() -> gameObject layer : " + gameObject.layer);
        Debug.Log("[ExampleExtensions] Start() -> grandChild layer : " + grandChild.gameObject.layer);
    }
}
