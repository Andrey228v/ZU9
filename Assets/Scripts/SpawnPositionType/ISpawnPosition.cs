using System;
using UnityEngine;

namespace Assets.Scripts.SpawnPositionType
{
    public interface ISpawnPosition
    {
        public event Action SetedPointForSpawn;

        public Vector3 GetSpawnPosition();

        public void SetPoinForSpawn(Transform Point);
    }
}
