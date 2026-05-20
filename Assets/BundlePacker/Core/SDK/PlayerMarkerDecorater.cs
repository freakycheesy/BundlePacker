using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BundlePacker.Core
{
    public abstract class PlayerMarkerDecorater : MonoBehaviour
    {
        private void Awake()
        {
            PlayerMarker.onPlayerSpawned += OnSpawnPlayer;
        }

        public abstract void OnSpawnPlayer(object instance);
    }
}