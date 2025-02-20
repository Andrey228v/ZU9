using System;
using UnityEngine;

namespace Assets.Scripts
{
    public interface ISpawnObject<T> where T : Component
    {
        public event Action<T> DestroedSpawnObject;
    }
}
