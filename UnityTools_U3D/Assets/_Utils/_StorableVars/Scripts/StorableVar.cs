using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StorableVar
{
    private string _varName;

    protected string VarName
    {
        get { return _varName; }
        set { _varName = value; }
    }

    protected bool Exists
    {
        get
        {
            return PlayerPrefs.HasKey(VarName);
        }
    }

    private void CleanPlayerPrefs()
    {
        //PlayerPrefs.DeleteAll();
    }

    public void CleanPlayerPrefsByKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    #region STRINGS
    protected void SetValue(string newValue)
    {
        PlayerPrefs.SetString(VarName, newValue);
        PlayerPrefs.Save();
    }
    protected string GetString()
    {
        try
        {
            return PlayerPrefs.GetString(VarName);
        } catch (Exception e)
        {
            CleanPlayerPrefs();
            CleanPlayerPrefsByKey(VarName);
            Debug.LogError("StorableVar String - Error: " + e.Message);
            return "";
        }
    }
    #endregion

    #region INT
    protected void SetValue(int newValue)
    {
        PlayerPrefs.SetString(VarName, newValue.ToString());
        PlayerPrefs.Save();
    }
    protected int GetInt()
    {
        try
        {
            string intValue = PlayerPrefs.GetString(VarName);
            if (string.IsNullOrEmpty(intValue))
            {
                return 0;
            }
            else
            {
                return int.Parse(intValue);
            }
        }
        catch (Exception e)
        {
            CleanPlayerPrefs();
            Debug.LogError("StorableVar Int - Error: " + e.Message);
            return 0;
        }
    }
    #endregion

    #region FLOAT
    protected void SetValue(float newValue)
    {
        PlayerPrefs.SetString(VarName, newValue.ToString());
        PlayerPrefs.Save();
    }
    protected float GetFloat()
    {
        try
        {
            string floatValue = PlayerPrefs.GetString(VarName);
            if (string.IsNullOrEmpty(floatValue))
            {
                return 0;
            }
            else
            {
                return float.Parse(floatValue);
            }
        }
        catch (Exception e)
        {
            CleanPlayerPrefs();
            Debug.LogError("StorableVar Float - Error: " + e.Message);
            return 0;
        }
    }
    #endregion

    #region LONG
    protected void SetValue(long newValue)
    {
        PlayerPrefs.SetString(VarName, newValue.ToString());
        PlayerPrefs.Save();
    }
    protected long GetLong()
    {
        try
        {
            string floatValue = PlayerPrefs.GetString(VarName);
            if (string.IsNullOrEmpty(floatValue))
            {
                return 0;
            }
            else
            {
                return long.Parse(floatValue);
            }
        }
        catch (Exception e)
        {
            CleanPlayerPrefs();
            Debug.LogError("StorableVar Long - Error: " + e.Message);
            return 0;
        }
    }
    #endregion

    #region BOOL
    protected void SetValue(bool newValue)
    {
        PlayerPrefs.SetString(VarName, newValue.ToString()  );
    }
    protected bool GetBool()
    {
        try
        {
            string boolValue = PlayerPrefs.GetString(VarName);
            if (string.IsNullOrEmpty(boolValue))
            {
                return false;
            } else
            {
                return bool.Parse(boolValue);
            }
        }
        catch (Exception e)
        {
            CleanPlayerPrefs();
            Debug.LogError("StorableVar Bool - Error: " + e.Message);
            return false;
        }
    }
    #endregion

    #region BYTES
    protected void SetValue(byte[] newValue)
    {
        PlayerPrefs.SetString(VarName, newValue.ToString());
    }
    protected byte[] GetBytes()
    {
        try
        {
            return Convert.FromBase64String( PlayerPrefs.GetString(VarName));
            
        }
        catch (Exception e)
        {
            CleanPlayerPrefs();
            Debug.LogError("StorableVar Bool - Error: " + e.Message);
            return null;
        }
    }
    #endregion

    #region VECTOR3
    protected void SetValue(Vector3 newValue)
    {
        PlayerPrefs.SetString(VarName, newValue.ToString());
    }
    protected Vector3 GetVector3()
    {
        try
        {
            string vector3Value = PlayerPrefs.GetString(VarName);
            if (string.IsNullOrEmpty(vector3Value))
            {
                return Vector3.positiveInfinity;
            }
            else
            {
                return JsonConvert.DeserializeObject<Vector3>(vector3Value);
            }

        }
        catch (Exception e)
        {
            CleanPlayerPrefs();
            Debug.LogError("StorableVar Vector3 - Error: " + e.Message);
            return Vector3.positiveInfinity;
        }
    }
    #endregion
    
    #region DICTIONARY
    protected void SetDictionary<TKey, TValue>(Dictionary<TKey, TValue> newDict)
    {
        string dictString = JsonConvert.SerializeObject(newDict);
        PlayerPrefs.SetString(VarName, dictString);
        PlayerPrefs.Save();
    }
    protected Dictionary<TKey, TValue> GetDictionary<TKey, TValue>()
    {
        try
        {
            string dictString = PlayerPrefs.GetString(VarName);
            if (string.IsNullOrEmpty(dictString))
            {
                return new Dictionary<TKey, TValue>();
            }
            else
            {
                return JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(dictString);
            }
        }
        catch (Exception e)
        {
            CleanPlayerPrefs();
            Debug.LogError("StorableVar Dictionary - Error: " + e.Message);
            return new Dictionary<TKey, TValue>();
        }
    }
    #endregion
}
