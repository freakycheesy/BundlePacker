using System;
using UnityEngine;

namespace BundlePacker.Core
{
    public class PlayerMarker : MonoBehaviour
    {
        public static PlayerMarker instance;
        public static Action onInstanceCreated;
        public static Action<object> onPlayerSpawned;
        public Mesh previewPlayerMarker;
        private void Start()
        {
            instance = this;
            onInstanceCreated?.Invoke();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireMesh(previewPlayerMarker, transform.position, transform.rotation);
        }
    }
}