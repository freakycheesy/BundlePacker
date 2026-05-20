using System.Collections.Generic;
using UnityEngine;
namespace BundlePacker.Core
{
    [CreateAssetMenu(fileName = "Pallet", menuName = "BundlePacker/Pallet")]
    public class Pallet : Scannable
    {
        public string author;
        public string version;
        public List<Crate> crates = new List<Crate>();

#if UNITY_EDITOR
        public UnityEditor.SceneAsset[] scenes;
#endif

        [ContextMenu("Generate Barcode")]
        public override void GenerateBarcode()
        {
            id = $"{author}.{title}".Replace(" ", "");
        }

        [ContextMenu("Generate Crates Barcode")]
        public void GenerateCratesBarcode()
        {
            crates.ForEach(x => x.GenerateBarcode());
        }

        public override void Validate()
        {
            crates.ForEach(x => x.Validate());
        }
    }
}