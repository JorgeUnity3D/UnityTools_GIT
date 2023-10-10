using System.Threading.Tasks;
using UnityEngine;

public class ExampleWithKeyStore : MonoBehaviour
{
    [SerializeField] private string _keyStoreName = "KeyStoreFile.r4wD4T4";

    ExampleKeyStore _keyStore;

    private async void Start()
    {
        await GetKeys();
        Debug.Log("[ExampleWithKeyStore] Start() -> _keyStore.apiUrl: " + _keyStore.apiUrl);
        Debug.Log("[ExampleWithKeyStore] Start() -> _keyStore.apiKey: " + _keyStore.apiKey);
    }

    private async Task GetKeys()
    {
        await FileManager.LoadEncryptedFile<ExampleKeyStore>(_keyStoreName, (keyStore) =>
        {
            _keyStore = keyStore;
            Debug.Log("[ExampleWithKeyStore] GetKeys() -> _keyStore.apiUrl: " + _keyStore.apiUrl);
            Debug.Log("[ExampleWithKeyStore] GetKeys() -> _keyStore.apiKey: " + _keyStore.apiKey);
        });
    }
}
