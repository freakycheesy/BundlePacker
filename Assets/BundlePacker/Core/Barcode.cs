using System;
using UnityEngine;

[Serializable]
public struct Barcode<T> where T : Crate
{
    public string id;
#if UNITY_EDITOR
    public Crate cache;
#endif
}
