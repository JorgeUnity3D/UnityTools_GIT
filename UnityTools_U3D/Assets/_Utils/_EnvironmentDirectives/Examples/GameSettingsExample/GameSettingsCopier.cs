using UnityEngine;
[CreateAssetMenu(fileName = "GameSettingsCopier", menuName = "Settings/Copiers/GameSettingsCopier")]
public class GameSettingsCopier : ScriptableCopierDataObject
{
    public override void CopyData()
    {
        var src = source as EnvironmentSettingsDataObject;
        var dst = destination as GameSettingsDataObject;
        if (src != null && dst != null)
        {
            EnvironmentSettings settingsToCopy;
            #if DEV
            settingsToCopy = src.devSettings;
            #elif PROD
            settingsToCopy = src.prodSettings;
            #else
            Debug.LogError("Neither DEV nor PROD directive is defined.");
            return;
            #endif
            dst.environmentSettings = settingsToCopy;
        }
        else
        {
            Debug.LogError("Invalid source or destination type");
        }
    }
}