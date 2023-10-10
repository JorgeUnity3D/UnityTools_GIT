using UnityEditor;

public static class EnvironmentDirectiveSetter
{
    [MenuItem("Build/Set Environment/Dev")]
    public static void SetDevDirectives()
    {
        SetDirectives(EnvironmentDirectives.DEV);
    }

    [MenuItem("Build/Set Environment/Prod")]
    public static void SetProdDirectives()
    {
        SetDirectives(EnvironmentDirectives.PROD);
    }

    private static void SetDirectives(string directive)
    {
        PlayerSettings.SetScriptingDefineSymbols(UnityEditor.Build.NamedBuildTarget.Standalone, directive);
        PlayerSettings.SetScriptingDefineSymbols(UnityEditor.Build.NamedBuildTarget.WebGL, directive);
        PlayerSettings.SetScriptingDefineSymbols(UnityEditor.Build.NamedBuildTarget.Android, directive);
    }
}
