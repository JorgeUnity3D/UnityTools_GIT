using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(KeyStoreDataObject<>), true)]
public class KeyStoreDataObjectInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        IKeyStoreDataObject script = target as IKeyStoreDataObject;
        if (GUILayout.Button("Create Encrypted File", GUILayout.MinWidth(80), GUILayout.MaxWidth(200)))
        {
            script.CreateProtectedKeyStoreFile();
        }
    }
}
