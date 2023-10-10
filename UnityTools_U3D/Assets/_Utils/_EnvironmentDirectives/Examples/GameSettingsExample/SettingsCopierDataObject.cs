using UnityEngine;

public abstract class ScriptableCopierDataObject : ScriptableObject
{
    public ScriptableObject source;
    public ScriptableObject destination;

    public abstract void CopyData();
}