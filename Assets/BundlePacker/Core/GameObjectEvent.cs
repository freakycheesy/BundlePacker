using System;
using UnityEngine;
using UnityEngine.Events;
namespace BundlePacker.Core
{
    [Serializable]
    public class GameObjectEvent : UnityEvent<GameObject>
    {
    }
}