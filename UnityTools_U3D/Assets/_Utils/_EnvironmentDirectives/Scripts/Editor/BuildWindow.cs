using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildWindow : EditorWindow
{
    bool _isDev;
    bool _isProd;
    string _directive;
    private List<SceneAsset> _scenes = new List<SceneAsset>();
    private List<ScriptableCopierDataObject> settingsCopiers = new List<ScriptableCopierDataObject>();

    [MenuItem("Build/Set Up Build")]
    public static void ShowWindow()
    {
        BuildWindow window = EditorWindow.GetWindow<BuildWindow>("New Build");
        window.Show();
    }

    private void OnEnable()
    {
        string currentDirective = EnvironmentDirectiveSetter.CurrentEnvironmentDirectives;
        _isDev = currentDirective == EnvironmentDirectives.DEV;
        _isProd = currentDirective == EnvironmentDirectives.PROD;
    }

    #region ONGUI

    private void OnGUI()
    {
        SelectEnvironment();
        EditorGUILayout.Separator();
        ManageSettingsCopiers();
        EditorGUILayout.Separator();
        SelectScenes();
        EditorGUILayout.Separator();
        SelectBuild();
    }

    private void SelectEnvironment()
    {
        GUILayout.Label("Select Environment:", EditorStyles.boldLabel);
        EditorGUI.BeginChangeCheck();
        _isDev = EditorGUILayout.Toggle(EnvironmentDirectives.DEV, _isDev);
        if (EditorGUI.EndChangeCheck() && _isDev)
        {
            _isProd = false;
            UpdateEnvironmentDirective();
        }

        EditorGUI.BeginChangeCheck();
        _isProd = EditorGUILayout.Toggle(EnvironmentDirectives.PROD, _isProd);
        if (EditorGUI.EndChangeCheck() && _isProd)
        {
            _isDev = false;
            UpdateEnvironmentDirective();
        }
    }

    private void ManageSettingsCopiers()
    {
        EditorGUILayout.LabelField("Settings Copiers", EditorStyles.boldLabel);
        for (int i = 0; i < settingsCopiers.Count; i++)
        {
            settingsCopiers[i] = (ScriptableCopierDataObject)EditorGUILayout.ObjectField(settingsCopiers[i], typeof(ScriptableCopierDataObject), false);
        }
        if (GUILayout.Button("Add Copier"))
        {
            settingsCopiers.Add(null);
        }
        if (GUILayout.Button("Remove Last Copier") && settingsCopiers.Count > 0)
        {
            settingsCopiers.RemoveAt(settingsCopiers.Count - 1);
        }
    }

    private void SelectScenes()
    {
        EditorGUILayout.LabelField("Scenes In Build:", EditorStyles.boldLabel);
        RefreshSceneList();
        for (int i = 0; i < _scenes.Count; i++)
        {
            _scenes[i] = (SceneAsset)EditorGUILayout.ObjectField($"Scene {i + 1}:", _scenes[i], typeof(SceneAsset), false);
        }
        if (GUILayout.Button("Add Scene"))
        {
            _scenes.Add(null);
        }
        if (GUILayout.Button("Remove Last Scene") && _scenes.Count > 0)
        {
            _scenes.RemoveAt(_scenes.Count - 1);
        }
    }

    private void SelectBuild()
    {
        if (GUILayout.Button("BUILD"))
        {
            EnvironmentDirectiveSetter.CurrentEnvironmentDirectives = _isDev ? EnvironmentDirectives.DEV : EnvironmentDirectives.PROD;
            string buildPath = PerformBuild();
            if (string.IsNullOrEmpty(buildPath)) // PerformBuild returns null if the build failed or was cancelled
            {
                return;
            }
        }

        if (GUILayout.Button("BUILD AND RUN"))
        {
            EnvironmentDirectiveSetter.CurrentEnvironmentDirectives = _isDev ? EnvironmentDirectives.DEV : EnvironmentDirectives.PROD;
            string buildPath = PerformBuild();
            if (string.IsNullOrEmpty(buildPath)) // PerformBuild returns null if the build failed or was cancelled
            {
                return;
            }

            System.Diagnostics.Process.Start(buildPath);
        }
    }

    #endregion

    #region CONTROL

    private void RefreshSceneList()
    {
        _scenes.Clear();
        foreach (EditorBuildSettingsScene editorScene in EditorBuildSettings.scenes)
        {
            if (editorScene.enabled)
            {
                SceneAsset sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(editorScene.path);
                _scenes.Add(sceneAsset);
            }
        }
    }

    private void UpdateEnvironmentDirective()
    {
        if (_isDev)
        {
            EnvironmentDirectiveSetter.CurrentEnvironmentDirectives = EnvironmentDirectives.DEV;
        }
        else if (_isProd)
        {
            EnvironmentDirectiveSetter.CurrentEnvironmentDirectives = EnvironmentDirectives.PROD;
        }
    }
    
    #endregion

    #region BUILD

    private string PerformBuild()
    {
        CopyDataFromCopiers();
        List<string> scenePaths = GetScenePaths();
        BuildTarget currentBuildTarget = EditorUserBuildSettings.activeBuildTarget;
        string buildPath = GetBuildPath(currentBuildTarget);  // Update this line
        if (string.IsNullOrEmpty(buildPath))
        {
            return null; // User cancelled the folder dialog
        }
        BuildReport report = BuildPlayer(scenePaths.ToArray(), buildPath, currentBuildTarget);  // Update this line
        return HandleBuildReport(report, buildPath);  // Update this line
    }

    private void CopyDataFromCopiers()
    {
        foreach (var copier in settingsCopiers)
        {
            copier.CopyData();
        }
    }

    private List<string> GetScenePaths()
    {
        List<string> scenePaths = new List<string>();
        foreach (SceneAsset scene in _scenes)
        {
            if (scene != null)
            {
                string path = AssetDatabase.GetAssetPath(scene);
                scenePaths.Add(path);
            }
        }
        return scenePaths;
    }

    private string GetBuildPath(BuildTarget buildTarget)
    {
        // Get the last used build path, or use an empty string if none found
        string lastUsedPath = EditorPrefs.GetString("LastUsedBuildPath", "");
    
        // Get the default extension for the build target
        string extension = GetDefaultExtension(buildTarget);
    
        // Get the build path from the user, including file name
        string buildPath = EditorUtility.SaveFilePanel("Choose location of build", lastUsedPath, "MyBuild", extension);
    
        // Save the build path for next time, excluding file name
        if (!string.IsNullOrEmpty(buildPath))
        {
            string directoryPath = System.IO.Path.GetDirectoryName(buildPath);
            EditorPrefs.SetString("LastUsedBuildPath", directoryPath);
        }
    
        return buildPath;
    }

    private BuildReport BuildPlayer(string[] scenePaths, string buildPath, BuildTarget buildTarget)  // Update the method signature
    {
        BuildPlayerOptions buildOptions = new BuildPlayerOptions
        {
            scenes = scenePaths,
            locationPathName = buildPath,  // Update this line
            target = buildTarget
        };

        return BuildPipeline.BuildPlayer(buildOptions);
    }

    private string HandleBuildReport(BuildReport report, string locationPathName)
    {
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            return locationPathName; // Return the path of the built executable
        }
        else if (summary.result == BuildResult.Failed)
        {
            Debug.LogError("Build failed");
            return null; // Return null if the build failed
        }

        return null; // Return null for other cases (e.g. BuildResult.Cancelled)
    }

    private string GetDefaultExtension(BuildTarget buildTarget)
    {
        switch (buildTarget)
        {
            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                return "exe";
            case BuildTarget.Android:
                return "apk";
            // ... add other platforms as needed
            default:
                return "";  // Default extension
        }
    }

    #endregion

}