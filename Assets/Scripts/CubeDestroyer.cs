using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CubeDestroyer : MonoBehaviour
    {
        [SerializeField] private Timer _timer;

        private int _minTimeLife = 2;
        private int _maxTimeLife = 5;

        public event Action Destroed;

        private void OnEnable()
        {
            _timer.Stoping += DestroyCube;
        }

        private void OnDisable()
        {
            _timer.ResetTime();
            _timer.Stoping -= DestroyCube;
        }

        public void StartDestroy()
        {
            float timeLife = UnityEngine.Random.Range(_minTimeLife, _maxTimeLife);
            _timer.SetStopTime(timeLife);
            _timer.StartTimer();
        }

        public void DestroyCube()
        {
            Destroed?.Invoke();
        }
    }
}
