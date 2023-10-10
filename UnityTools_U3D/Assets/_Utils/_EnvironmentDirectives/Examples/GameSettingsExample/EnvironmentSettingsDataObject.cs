using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentSettingsDataObject", menuName = "Settings/EnvironmentSettingsDataObject")]
public class EnvironmentSettingsDataObject : ScriptableObject
{
    public EnvironmentSettings devSettings;
    public EnvironmentSettings prodSettings;
}