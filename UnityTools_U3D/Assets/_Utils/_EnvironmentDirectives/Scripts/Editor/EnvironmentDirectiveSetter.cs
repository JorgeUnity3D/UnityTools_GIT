using UnityEditor;
using UnityEngine;

public static class EnvironmentDirectiveSetter
{
    public static string CurrentEnvironmentDirectives
    {
        get
        {
            return PlayerSettings.GetScriptingDefineSymbols(UnityEditor.Build.NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup));
        }
        set
        {
            PlayerSettings.SetScriptingDefineSymbols(UnityEditor.Build.NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup), value);
            DebugCurrentEnvironment();
        }
    }
    
    [MenuItem("Build/Set Environment/Dev")]
    public static void SetDevDirectives()
    {
        CurrentEnvironmentDirectives = EnvironmentDirectives.DEV;
    }

    [MenuItem("Build/Set Environment/Prod")]
    public static void SetProdDirectives()
    {
        CurrentEnvironmentDirectives = EnvironmentDirectives.PROD;
    }
    
    [MenuItem("Build/Set Environment/Current?")]
    public static void DebugCurrentEnvironment()
    {
        Debug.Log(CurrentEnvironmentDirectives);
    }
}
