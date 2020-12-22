using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TiagoTijolo
{
    [System.Serializable] public class IntUnityEvent : UnityEvent<int> { }

    public class ConstantBreathingStep : MonoBehaviour
    {
        public UnityEvent OnStepConcluded = new UnityEvent();
        
        public IntUnityEvent OnBreathTaken = new IntUnityEvent();
        public int BreathsTaken 
        { 
            get => _breathsTaken; 
            set { _breathsTaken = value; OnBreathTaken.Invoke(_breathsTaken); } 
        }

        [Range(10, 40)]
        public int MaxBreathingTimes = 30;
        public float BreathingTime = 1f;

        private int _breathsTaken;

        public IEnumerator Breath()
        {
            yield return new WaitForSeconds(BreathingTime);
            BreathsTaken++;

            if (BreathsTaken >= MaxBreathingTimes)
            {
                OnStepConcluded.Invoke();
            }
            else
            {
                StartCoroutine(Breath());
            }
        }

        private void OnEnable()
        {
            BreathsTaken = 0;
            StartCoroutine(Breath());
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}