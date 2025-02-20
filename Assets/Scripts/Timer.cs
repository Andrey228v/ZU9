using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        private float _perSecond = 0;
        private float _second = 1f;
        private float _stopTime = 0;
        private float _period = 1f;
        private float _relativeTime = 1f;

        public event Action StartingTimer;
        public event Action StopingTimer;
        public event Action<string> ChangingTime;
        public event Action<float> TickingPeriod;

        public float Time { get; private set; }
        public bool IsWorking { get; private set; } = false;
        public float TimeWithPeriod { get; private set; } = 0f;

        private void Update()
        {
            if (IsWorking)
            {
                if (Time <= _stopTime)
                {
                    Time += UnityEngine.Time.deltaTime;
                    ChangingTime?.Invoke(GetLeftTime());
                }
                else
                {
                    StopingTimer?.Invoke();
                    IsWorking = false;
                }

                if (Time >= TimeWithPeriod)
                {
                    TimeWithPeriod += _period;
                    _relativeTime = 1 - TimeWithPeriod/_stopTime;
                    TickingPeriod?.Invoke(_relativeTime);
                }
            }
        }

        public void StartTimer()
        {
            StartingTimer?.Invoke();
            IsWorking = true;
        }

        public void SetStopTime(float time)
        {
            _stopTime = time;
        }

        public void ResetTime()
        {
            IsWorking = false;
            TimeWithPeriod = 0f;
            _relativeTime = 1f;
            Time = 0;
        }

        public string GetLeftTime()
        {
            return (_stopTime - Time > 0) ? (_stopTime - Time).ToString("F1") : String.Empty;
        }
    }
}
