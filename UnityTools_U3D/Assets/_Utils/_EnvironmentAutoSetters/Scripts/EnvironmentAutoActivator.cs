using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAutoActivator : MonoBehaviour
{
    [Header("Activate if...")]
    public bool activateOnAndroid = false;
    public bool activateOnWeb = true;
    private void Awake()
    {
#if UNITY_ANDROID
        gameObject.SetActive(activateOnAndroid);
#endif
#if UNITY_WEBGL || UNITY_STANDALONE
        gameObject.SetActive(activateOnWeb);
#endif
    }
}
