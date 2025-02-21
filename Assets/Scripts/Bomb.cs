using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bomb : MonoBehaviour, ISpawnObject<Bomb>
    {
        [field: SerializeField] public Explosion Explosion { get; private set; }
        [field: SerializeField] public Timer Timer { get; private set; }

        private int _minTimeLife = 2;
        private int _maxTimeLife = 5;

        public event Action<Bomb> DestroedSpawnObject;

        private void OnEnable()
        {
            Timer.Stoping += Explosion.CreateExplosion;
            Explosion.Exploded += Despawn;

            float timeLife = UnityEngine.Random.Range(_minTimeLife, _maxTimeLife);
            Timer.SetStopTime(timeLife);
            Timer.StartTimer();
        }

        private void OnDisable()
        {
            Timer.Stoping -= Explosion.CreateExplosion;
            Explosion.Exploded -= Despawn;
        }

        public void Despawn()
        {
            Timer.ResetTime();
            DestroedSpawnObject?.Invoke(this);
        }
    }
}
