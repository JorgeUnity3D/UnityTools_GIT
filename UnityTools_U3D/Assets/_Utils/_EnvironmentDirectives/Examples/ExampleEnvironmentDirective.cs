using UnityEngine;


public class ExampleEnvironmentDirective : MonoBehaviour
{
    void Start()
    {
#if DEV
        Debug.Log("[ExampleEnvironmentDirective] Start() -> DEV");
#endif
#if PROD
        Debug.Log("[ExampleEnvironmentDirective] Start() -> PROD");
#endif
    }
}
