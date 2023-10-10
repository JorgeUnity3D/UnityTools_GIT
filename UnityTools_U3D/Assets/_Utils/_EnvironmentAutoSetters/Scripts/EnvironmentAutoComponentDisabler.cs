using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnvironmentAutoComponentDisabler : MonoBehaviour
{
    
    [Header("Disable if...")]
    [SerializeField] private bool disableOnAndroid = false;
    [SerializeField] private bool disableOnWeb = true;

    [SerializeField] private List<Behaviour> _components;
    [SerializeField] private List<Collider> _colliders;
    private void Awake()
    {
#if UNITY_ANDROID
        if (disableOnAndroid)
        {
            DisableComponents();
            DisableColliders();
        }
#endif
#if UNITY_WEBGL || UNITY_STANDALONE
        if (disableOnWeb)
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
            component.enabled= false;
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
