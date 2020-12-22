using System;
using UnityEngine;

namespace TiagoTijolo
{
    public class BreathingObject : MonoBehaviour
    {
        [SerializeField] private BreathingData breathingData = default;
        
        private Animator _animator = null;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnInpirationStarted()
        {
            _animator.Play("ScaleUp");
        }

        private void OnExpirationStarted()
        {
            _animator.Play("ScaleDown");
        }

        private void OnEnable()
        {
            _animator.speed = 2f / breathingData.BreathingTime;
            breathingData.OnInspirationStarted.AddListener(OnInpirationStarted);
            breathingData.OnExpirationStarted.AddListener(OnExpirationStarted);
        }

        private void OnDisable()
        {
            breathingData.OnInspirationStarted.RemoveListener(OnInpirationStarted);
            breathingData.OnExpirationStarted.RemoveListener(OnExpirationStarted);
        }


    }
}