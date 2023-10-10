using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAutoDestroyer : MonoBehaviour
{
    [Header("Destroy if...")]
    public bool destroyOnAndroid = false;
    public bool destroyOnWeb = true;
    private void Awake()
    {
#if UNITY_ANDROID
        if (destroyOnAndroid)
        {
            Destroy(gameObject);
        }
#endif
#if UNITY_WEBGL || UNITY_STANDALONE
        if (destroyOnWeb)
        {
            Destroy(gameObject);
        }
#endif
    }
}
