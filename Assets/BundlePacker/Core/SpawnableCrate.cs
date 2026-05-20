using UnityEngine;

[CreateAssetMenu(fileName = "SpawnableCrate", menuName = "BundlePacker/SpawnableCrate")]
public class SpawnableCrate : Crate
{
    public GameObject asset;
    public override Object GetAsset() => asset;

    public override void SetAsset(Object asset) => this.asset = (GameObject)asset;
}
