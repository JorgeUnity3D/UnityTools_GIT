using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAutoActivator : MonoBehaviour
{
    [Header("Activate if...")]
    [SerializeField] private PlatformsMask _activateOnPlatforms;

    private void Awake()
    {
#if UNITY_STANDALONE
        if ((_activateOnPlatforms & PlatformsMask.Standalone) == PlatformsMask.Standalone)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
#endif
#if UNITY_IOS
        if ((_activateOnPlatforms & PlatformsMask.iOS) == PlatformsMask.iOS)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
#endif
#if UNITY_ANDROID
        if ((_activateOnPlatforms & PlatformsMask.Android) == PlatformsMask.Android)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
#endif
#if UNITY_WEBGL
        if ((_activateOnPlatforms & PlatformsMask.WebGL) == PlatformsMask.WebGL)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
#endif
    }
}
