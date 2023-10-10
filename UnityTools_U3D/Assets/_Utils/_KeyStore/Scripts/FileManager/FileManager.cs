using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class FileManager
{
    #region CONTROL

    public static void WriteEncryptedFile<T>(string fileName, T keystore) where T : class
    {
        Debug.Log("[FileManager] WriteEncryptedFile()");

        Encrypter encrypter = new Encrypter();
        string encryptedFileName = encrypter.Encrypt(fileName);
        string json = JsonConvert.SerializeObject(keystore);
        string encryptedJson = encrypter.Encrypt(json);
        string filePath = Path.Combine(Application.streamingAssetsPath, encryptedFileName + ".json");
        WriteToFile(filePath, encryptedJson);
    }

    public static bool WriteToFile(string a_FileName, string a_FileContents)
    {
        Debug.Log("[FileManager] WriteToFile()");

        var fullPath = Path.Combine(Application.persistentDataPath, a_FileName);
        var directoryPath = Path.GetDirectoryName(fullPath);

        try
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(fullPath, a_FileContents);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
            return false;
        }
    }

    public static async Task LoadEncryptedFile<T>(string fileName, Action<T> OnSuccess) where T : class
    {
        Encrypter encrypter = new Encrypter();
        string encryptedFileName = encrypter.Encrypt(fileName);
        string filePath = Path.Combine(Application.streamingAssetsPath, encryptedFileName + ".json");
#if UNITY_STANDALONE_OSX
        filePath = "file://" + Path.Combine(Application.dataPath, "StreamingAssets", encryptedFileName + ".json");
#endif
        Debug.Log("[FileManager] LoadEncryptedFile() -> filePath: " + filePath);
        try
        {
            string message = await AsyncRequest(filePath);
            string json = encrypter.Decrypt(message);
            Debug.Log("[FileManager] LoadEncryptedFile() -> json: " + json);
            T keystore = JsonConvert.DeserializeObject<T>(json);
            OnSuccess?.Invoke(keystore);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to load encrypted file: {ex.Message}");
        }
    }

    #endregion

    #region REQUEST 

    private static async Task<string> AsyncRequest(string path)
    {
        using UnityWebRequest request = UnityWebRequest.Get(path);
        UnityWebRequestAsyncOperation operation = request.SendWebRequest();
        while (!operation.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.Success)
        {
            return request.downloadHandler.text;
        }
        else
        {
            throw new Exception($"Request error: {request.error}");
        }
    }

    #endregion
}