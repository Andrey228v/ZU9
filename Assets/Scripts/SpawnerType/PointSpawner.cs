using Assets.Scripts.SpawnPositionType;
using System;
using UnityEngine;

namespace Assets.Scripts.SpawnerType
{
    public class PointSpawner<T> : MonoBehaviour, ISpawnerType where T : Component, ISpawnObject<T>
    {
        private ObjectPoolFigure<T> _poolFigure;

        public event Action Spawned;

        public ISpawnPosition SpawnPosition { get; private set; }

        private void Awake()
        {
            SpawnPosition = GetComponent<ISpawnPosition>();
            _poolFigure = GetComponent<ObjectPoolFigure<T>>();
        }

        public void Spawn()
        {
            T figure = _poolFigure.Pool.Get();

            Vector3 position = SpawnPosition.GetSpawnPosition();

            figure.transform.position = position;
            Spawned?.Invoke();
        }
    }
}
