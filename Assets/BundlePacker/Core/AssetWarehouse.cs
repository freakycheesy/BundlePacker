using System;
using System.Collections.Generic;
using UnityEngine;

public static class AssetWarehouse
{
    public static Dictionary<string, Pallet> pallets = new();
    public static Dictionary<string, Crate> crates = new();
    public static Action onInitialized;
    public static void Start(IBundleLoader loader)
    {
        var result = loader.FindBundles();
        foreach(var pallet in result.pallets)
        {
            AddPallet(pallet);
        }
        onInitialized?.Invoke();
    }

    public static void AddPallet(Pallet pallet)
    {
        pallets.Add(pallet.id, pallet);
        int length = pallet.crates.Count;
        for (int i = 0; i < length; i++)
        {
            crates.Add(pallet.crates[i].id, pallet.crates[i]);
        }
    }
}
