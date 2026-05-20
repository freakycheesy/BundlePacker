using UnityEngine;

[CreateAssetMenu(fileName = "LevelCrate", menuName = "BundlePacker/LevelCrate")]
public class LevelCrate : Crate
{
    public string scene;

    public override Object GetAsset()
    {
        return null;
    }

    public override void SetAsset(Object asset)
    {
    }
}