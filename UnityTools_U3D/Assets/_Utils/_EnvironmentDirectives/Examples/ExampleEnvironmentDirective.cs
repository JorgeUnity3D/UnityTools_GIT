using UnityEngine;


public class ExampleEnvironmentDirective : MonoBehaviour
{
    [SerializeField]
    GameSettingsDataObject _gameSettingsDataObject;
    void Start()
    {
#if DEV
        Debug.Log("[ExampleEnvironmentDirective] Start() -> DEV");
#elif PROD
        Debug.Log("[ExampleEnvironmentDirective] Start() -> PROD");
#endif
        Debug.Log("[ExampleEnvironmentDirective] Start() -> _gameSettingsDataObject.appId: " + _gameSettingsDataObject.environmentSettings.appID);
    }
}
