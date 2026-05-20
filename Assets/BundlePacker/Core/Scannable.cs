using UnityEngine;

public abstract class Scannable : ScriptableObject
{
    public string id;
    public string title;
    public string description;

    public abstract void GenerateBarcode();
    public virtual void Validate() { }
}
