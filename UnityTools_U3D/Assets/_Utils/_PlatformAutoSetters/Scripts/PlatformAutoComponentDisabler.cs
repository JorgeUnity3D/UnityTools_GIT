using System.Collections.Generic;
using UnityEngine;

public class PlatformAutoComponentDisabler : MonoBehaviour
{
    [Header("Target Components...")]
    [SerializeField] private List<Behaviour> _components;
    [SerializeField] private List<Collider> _colliders;

    [Header("Disable if...")]
    [SerializeField] private PlatformsMask _disableOnPlatforms;

    

    private void Awake()
    {
#if UNITY_STANDALONE
        if ((_disableOnPlatforms & PlatformsMask.Standalone) == PlatformsMask.Standalone)
        {
            DisableComponents();
            DisableColliders();
        }
#endif
#if UNITY_IOS
        if ((_disableOnPlatforms & PlatformsMask.iOS) == PlatformsMask.iOS)
        {
            DisableComponents();
            DisableColliders();
        }
#endif
#if UNITY_ANDROID
        if ((_disableOnPlatforms & PlatformsMask.Android) == PlatformsMask.Android)
        {
            DisableComponents();
            DisableColliders();
        }
#endif
#if UNITY_WEBGL
        if ((_disableOnPlatforms & PlatformsMask.WebGL) == PlatformsMask.WebGL)
        {
            DisableComponents();
            DisableColliders();
        }
#endif
    }

    private void DisableComponents()
    {
        for (int i = 0; i < _components.Count; i++)
        {
            Behaviour component = _components[i];
            component.enabled = false;
        }
    }

    private void DisableColliders()
    {
        for (int i = 0; i < _colliders.Count; i++)
        {
            Collider collider = _colliders[i];
            collider.enabled = false;
        }
    }
}
