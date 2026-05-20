using System;
using UnityEngine;

namespace BundlePacker.Core
{
    [RequireComponent(typeof(CrateSpawner))]
    public abstract class CrateSpawnerDecorater : MonoBehaviour
    {
        public CrateSpawner spawner { get; set; }
        private void Awake()
        {
            spawner = GetComponent<CrateSpawner>();
            spawner.onSpawn.AddListener(OnSpawn);
        }

        public abstract void OnSpawn(GameObject instance);
    }
}