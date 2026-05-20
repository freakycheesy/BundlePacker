using UnityEngine;
namespace BundlePacker.Core
{
    [CreateAssetMenu(fileName = "LevelCrate", menuName = "BundlePacker/LevelCrate")]
    public class LevelCrate : Crate
    {
        [Scene] public string scene;

        public override Object GetAsset()
        {
            return null;
        }

        public override void SetAsset(Object asset)
        {
        }
    }
}