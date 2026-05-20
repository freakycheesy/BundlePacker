using UnityEngine;

public abstract class Crate : Scannable
{
    public Pallet pallet;
    public string[] tags;
    public bool redacted;
    public bool unlockable;
    public abstract Object GetAsset();
    public abstract void SetAsset(Object asset);
    [ContextMenu("Generate Barcode")]
    public override void GenerateBarcode()
    {
        id = $"{pallet.id}.{title}";
    }
}
