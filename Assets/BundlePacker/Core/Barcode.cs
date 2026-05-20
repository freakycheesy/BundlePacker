using System;
namespace BundlePacker.Core
{
    [Serializable]
    public struct Barcode
    {
        public string id;
#if UNITY_EDITOR
        public Crate cache;
#endif
    }
}
