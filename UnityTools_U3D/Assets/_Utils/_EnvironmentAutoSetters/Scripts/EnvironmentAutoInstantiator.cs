using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAutoInstantiator : MonoBehaviour
{
    [Header("Prefabs to instantiate")]
    public GameObject prefab;

    [Header("Instantiate if...")]
    public bool instantiateOnAndroid = false;
    public bool instantiateOnWeb = true;
    private void Awake()
    {
#if UNITY_ANDROID
        if (instantiateOnAndroid)
        {
            InstantiateNewPrefab();
        }
#endif
#if UNITY_WEBGL || UNITY_STANDALONE
        if (instantiateOnWeb)
        {
            InstantiateNewPrefab();
        }
#endif
    }

    private void InstantiateNewPrefab()
    {
        Instantiate(prefab);
        Destroy(gameObject);
    }
}
