using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SampleBundlePacker : MonoBehaviour, IBundleLoader
{
    public List<Pallet> pallets;
    public LoadBundleResult FindBundles()
    {
        var paths = Directory.GetFiles(Path.Combine(Application.streamingAssetsPath, "Mods"));
        foreach (var path in paths)
        {
            if (!path.EndsWith(".bundle")) continue;
            var bundle = AssetBundle.LoadFromFile(path);
            if (bundle == null) continue;
            if (!bundle.name.Contains(".scenes"))
                pallets.AddRange(bundle.LoadAllAssets<Pallet>());
        }
        return new()
        {
            pallets = pallets.ToArray()
        };
    }

    void Start()
    {
        AssetWarehouse.onInitialized += OnInit;
        AssetWarehouse.Start(this);
        SceneStreamer.defaultLoadLevel = loadLevel.id;
    }
    public Barcode<LevelCrate> loadLevel;
    public Barcode<LevelCrate> level;
    private void OnInit()
    {
        SceneStreamer.LoadLevel(level.id);
    }
}