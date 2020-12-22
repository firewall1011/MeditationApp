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
        
        [SerializeField] private BreathingData breathingData = null;

        public int BreathsTaken 
        { 
            get => _breathsTaken; 
            set { _breathsTaken = value; OnBreathTaken.Invoke(_breathsTaken); } 
        }
        
        private int _breathsTaken;

        public IEnumerator Breath()
        {
            breathingData.OnInspirationStarted.Invoke();
            yield return new WaitForSeconds(breathingData.BreathingTime / 2f);
            
            breathingData.OnExpirationStarted.Invoke();
            yield return new WaitForSeconds(breathingData.BreathingTime / 2f);
            
            BreathsTaken++;

            if (BreathsTaken >= breathingData.MaxBreathingTimes)
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