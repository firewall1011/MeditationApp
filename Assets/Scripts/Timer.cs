using System;
using UnityEngine;
using UnityEngine.Events;

namespace TiagoTijolo
{
    public class Timer : MonoBehaviour
    {
        public UnityEvent OnTimerEnd = new UnityEvent(); 
        public float TimeElapsed => _timer;
        public float TimeLeft => _countTime - _timer;

        public float GetCountTime() => _countTime;
        public void SetCountTime(float value) => _countTime = value;

        protected float _timer = 0f;
        protected float _countTime = 0f;
        protected bool _count = false;

        public void BeginTimer()
        {
            _timer = 0f;
            _count = true;
        }

        public void BeginTimer(float countTime)
        {
            SetCountTime(countTime);
            BeginTimer();
        }

        public void StopTimer() => _count = false;

        private void Update()
        {
            if (_count)
            {
                VerifyTime();
            }
        }
        protected void VerifyTime()
        {
            _timer += Time.deltaTime;

            if (_timer >= _countTime)
            {
                StopTimer();
                OnTimerEnd.Invoke();
            }
        }
    }
}