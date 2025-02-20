using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bomb : MonoBehaviour, ISpawnObject<Bomb>
    {
        [SerializeField] private BombView _bombView;
        [SerializeField] private Explosion _explosion;
        [SerializeField] private Timer _timer;

        private int _minTimeLife = 2;
        private int _maxTimeLife = 5;

        public event Action<Bomb> DestroedSpawnObject;

        private void OnEnable()
        {
            _timer.TickingPeriod += _bombView.SetAlphaParametr;
            _timer.StopingTimer += _explosion.CreateExplosion;
            _explosion.Exploded += Despawn;

            float timeLife = UnityEngine.Random.Range(_minTimeLife, _maxTimeLife);
            _timer.SetStopTime(timeLife);
            _timer.StartTimer();
        }

        private void OnDisable()
        {
            _timer.TickingPeriod -= _bombView.SetAlphaParametr;
            _timer.StopingTimer -= _explosion.CreateExplosion;
            _explosion.Exploded -= Despawn;
        }

        public void Despawn()
        {
            _bombView.SetDefaultParametrs();
            _timer.ResetTime();
            DestroedSpawnObject?.Invoke(this);
        }
    }
}
