using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BundlePacker.Core
{
    public class SpawnForce : CrateSpawnerDecorater
    {
        public Vector3 spawnVelocity;
        public Vector3 spawnAngularVelocity;
        public override void OnSpawn(GameObject instance)
        {
            var body = instance.GetComponentInChildren<Rigidbody>();
            body.velocity += spawnVelocity;
            body.angularVelocity += spawnAngularVelocity;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, spawnVelocity);
        }
    }
}

