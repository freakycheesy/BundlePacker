using BundlePacker.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-99)]
public class AssetWarehouse : MonoBehaviour, IBundleLoader
{
    public Pallet[] pallets;

    public LoadBundleResult FindBundles()
    {
        return new LoadBundleResult() { pallets = pallets };
    }

    private void Start()
    {
        BundlePacker.Core.AssetWarehouse.Start(this);
    }
}
