using UnityEngine;

public class PlatformAutoInstantiator : MonoBehaviour
{
    [Header("Target _prefab")]
    [SerializeField] private GameObject _prefab;

    [Header("Instantiate if...")]
    [SerializeField] private PlatformsMask _instantiateOnPlatforms;

    private void Awake()
    {
#if UNITY_STANDALONE
        if ((_instantiateOnPlatforms & PlatformsMask.Standalone) == PlatformsMask.Standalone)
        {
            InstantiateNew_prefab();
        }
#endif
#if UNITY_IOS
        if ((_instantiateOnPlatforms & PlatformsMask.iOS) == PlatformsMask.iOS)
        {
            InstantiateNew_prefab();
        }
#endif
#if UNITY_ANDROID
        if ((_instantiateOnPlatforms & PlatformsMask.Android) == PlatformsMask.Android)
        {
            InstantiateNew_prefab();
        }
#endif
#if UNITY_WEBGL
        if ((_instantiateOnPlatforms & PlatformsMask.WebGL) == PlatformsMask.WebGL)
        {
            InstantiateNew_prefab();
        }
#endif
    }

    private void InstantiateNew_prefab()
    {
        Instantiate(_prefab);
        Destroy(gameObject);
    }
}