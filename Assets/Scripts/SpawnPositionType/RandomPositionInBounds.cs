using System;
using UnityEngine;

namespace Assets.Scripts.SpawnPositionType
{
    [RequireComponent(typeof(Collider))]
    public class RandomPositionInBounds : MonoBehaviour, ISpawnPosition
    {
        private Vector3 _bounds;

        public event Action SetedPointForSpawn;

        public void Start()
        {
            _bounds = GetComponent<Collider>().bounds.extents;
        }

        public Vector3 GetSpawnPosition()
        {
            float x = UnityEngine.Random.Range(-_bounds.x, _bounds.x);
            float y = transform.position.y;
            float z = UnityEngine.Random.Range(-_bounds.z, _bounds.z);

            Vector3 position = new Vector3(x, y, z);

            return position;
        }

        public void SetPoinForSpawn(Transform Point)
        {
            SetedPointForSpawn?.Invoke();
        }
    }
}
