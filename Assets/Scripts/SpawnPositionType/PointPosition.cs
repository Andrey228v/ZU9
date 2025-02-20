using System;
using UnityEngine;

namespace Assets.Scripts.SpawnPositionType
{
    public class PointPosition : MonoBehaviour, ISpawnPosition
    {
        private Vector3 _position;

        public event Action SetedPointForSpawn;

        public Vector3 GetSpawnPosition()
        {
            return _position;
        }

        public void SetPoinForSpawn(Transform Point)
        {
            _position = Point.position;
            SetedPointForSpawn?.Invoke();
        }
    }
}
