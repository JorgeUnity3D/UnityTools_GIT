using UnityEngine;

public static class GameObjectExtensions
{
    public static void SetLayer(this GameObject target, int layer, bool forceChildren = false)
    {
        target.layer = layer;
        if (forceChildren)
        {
            var children = target.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                child.gameObject.layer = layer;
            }
        }
    }
}
