using Newtonsoft.Json;
using UnityEngine;

public abstract class KeyStoreDataObject<T> : ScriptableObject, IKeyStoreDataObject where T : KeyStore
{
    [SerializeField] private string _fileName = "KeyStoreFile.r4wD4T4";
    [SerializeField] private T _keyStore;

    public T KeyStore
    {
        get { return _keyStore; }
    }

    public void CreateProtectedKeyStoreFile()
    {
        FileManager.WriteEncryptedFile<T>(_fileName, _keyStore);
    }
}
