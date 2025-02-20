using Assets.Scripts.SpawnPositionType;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SpawnerType
{
    [RequireComponent(typeof(ISpawnPosition))]
    public class CyclingSpawner<T> : MonoBehaviour, ISpawnerType where T : Component, ISpawnObject<T>
    {
        [Min(0.1f)][SerializeField] private float _timeSpawn;

        private ObjectPoolFigure<T> _poolFigure;
        private bool _isSpawn = true;

        public event Action Spawned;

        public ISpawnPosition SpawnPosition { get; private set; }

        private void Awake()
        {
            SpawnPosition = GetComponent<ISpawnPosition>();
            _poolFigure = GetComponent<ObjectPoolFigure<T>>();
        }

        public void Spawn()
        {
            StartCoroutine(SpawnCyclingStart());
        }

        private IEnumerator SpawnCyclingStart()
        {
            while (_isSpawn)
            {
                T figure = _poolFigure.Pool.Get();
                Spawned?.Invoke();

                Vector3 position = SpawnPosition.GetSpawnPosition();
                figure.transform.position = position;

                yield return new WaitForSeconds(_timeSpawn);
            }
        }
    }
}
