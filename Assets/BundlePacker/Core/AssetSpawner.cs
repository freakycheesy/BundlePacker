using System;
using System.Collections.Generic;
using UnityEngine;

public static class AssetSpawner
{
    public static List<GameObject> spawned = new();
    public static void Spawn(string id, Vector3 position = default, Quaternion rotation = default, Vector3? scale = null, Transform parent = null, Action<GameObject> onSpawn = null)
    {
        var crate = (SpawnableCrate)AssetWarehouse.crates[id];
        if (crate is not SpawnableCrate) return;
        var result = UnityEngine.Object.Instantiate(crate.asset, position, rotation, parent);
        if (scale.HasValue) result.transform.localScale = scale.Value;
        onSpawn?.Invoke(result);
        spawned.Add(result);
    }
    public static void Despawn(GameObject instance)
    {
        if(spawned.Contains(instance)) spawned.Remove(instance);
        UnityEngine.Object.Destroy(instance);
    }
}
