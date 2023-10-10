using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAutoDestroyer : MonoBehaviour
{
    [Header("Destroy if...")]
    [SerializeField] private PlatformsMask _destroyOnPlatforms;

    private void Awake()
    {
#if UNITY_STANDALONE
        if ((_destroyOnPlatforms & PlatformsMask.Standalone) == PlatformsMask.Standalone)
        {
            Destroy(gameObject);
        }
#endif
#if UNITY_IOS
        if ((_destroyOnPlatforms & PlatformsMask.iOS) == PlatformsMask.iOS)
        {
            Destroy(gameObject);
        }
#endif
#if UNITY_ANDROID
        if ((_destroyOnPlatforms & PlatformsMask.Android) == PlatformsMask.Android)
        {
            Destroy(gameObject);
        }
#endif
#if UNITY_WEBGL
        if ((_destroyOnPlatforms & PlatformsMask.WebGL) == PlatformsMask.WebGL)
        {
            Destroy(gameObject);
        }
#endif
    }
}
