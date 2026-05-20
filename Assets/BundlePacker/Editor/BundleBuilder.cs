using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using BundlePacker.Core;

namespace BundlePacker.Editor
{
    public static class BundleBuilder
    {
        public static void BuildPallet(Pallet pallet, BuildTarget target)
        {
            string exportedPath = GetExportPath(pallet, target);

            AssetBundleBuild bundleBuild = CreateBundleBuild(pallet);
            AssetBundleBuild sceneBundleBuild = CreateSceneBundleBuild(pallet);

            Directory.CreateDirectory(exportedPath);

            GenerateBundles(target, exportedPath, bundleBuild, sceneBundleBuild);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            EditorUtility.DisplayDialog("Export completed!", $"Export completed at location:\n{exportedPath}", "OK");
        }
        private static string GetExportPath(Pallet pallet, BuildTarget target)
        {
            return Path.Combine(Application.dataPath, "AssetBundles", target.ToString(), pallet.id);
        }
        private static AssetBundleBuild CreateSceneBundleBuild(Pallet pallet)
        {
            AssetBundleBuild build = new AssetBundleBuild();

            build.assetBundleName += pallet.id.Replace(" ", "");
            build.assetBundleName += ".scenes";
            build.assetBundleName += ".bundle";

            List<string> assetNames = new List<string>();
            foreach (var scene in pallet.scenes)
                assetNames.Add(AssetDatabase.GetAssetPath(scene));

            build.assetNames = assetNames.ToArray();
            return build;
        }

        private static AssetBundleBuild CreateBundleBuild(Pallet pallet)
        {
            AssetBundleBuild build = new AssetBundleBuild();

            build.assetBundleName += pallet.id.Replace(" ", "");
            build.assetBundleName += ".bundle";

            List<string> assetNames = new List<string>();
            foreach (var crate in pallet.crates)
            {
                assetNames.Add(AssetDatabase.GetAssetPath(crate));
                assetNames.Add(AssetDatabase.GetAssetPath(crate.GetAsset()));
            }

            build.assetNames = assetNames.ToArray();
            return build;
        }

        private static void GenerateBundles(BuildTarget target, string exportPath, AssetBundleBuild build, AssetBundleBuild sceneBuild)
        {
            BuildPipeline.BuildAssetBundles(exportPath, new AssetBundleBuild[2] { build, sceneBuild }, BuildAssetBundleOptions.ChunkBasedCompression, target);
        }
    }
}