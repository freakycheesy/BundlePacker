using UnityEngine;

namespace BundlePacker.Core
{
    [DefaultExecutionOrder(1)]
    public class CrateSpawner : MonoBehaviour
    {
        public Barcode crate;
        public bool spawnOnStart = true;
        public GameObjectEvent onSpawn = new GameObjectEvent();
        private void Start()
        {
            if (spawnOnStart)
            {
                Spawn();
            }
        }
        private void OnValidate()
        {
            gameObject.isStatic = true;
            gameObject.layer = 2;
        }

        public void Spawn()
        {
            AssetSpawner.Spawn(crate.id, transform.position, transform.rotation, onSpawn: onSpawn.Invoke);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireMesh(crate.cache.previewMesh, transform.position, transform.rotation);
        }
#endif
    }
}