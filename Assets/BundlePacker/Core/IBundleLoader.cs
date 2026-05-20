using UnityEngine;
namespace BundlePacker.Core
{
    public interface IBundleLoader
    {
        LoadBundleResult FindBundles();
    }
}