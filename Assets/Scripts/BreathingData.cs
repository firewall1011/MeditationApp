using UnityEngine;
using UnityEngine.Events;

namespace TiagoTijolo
{
    [CreateAssetMenu(fileName = "BreathingData", menuName = "BreathingData")]
    public class BreathingData : ScriptableObject
    {
        public UnityEvent OnInspirationStarted = new UnityEvent();
        public UnityEvent OnExpirationStarted = new UnityEvent();
        
        [Range(1, 40)]
        public int MaxBreathingTimes = 30;
        public float BreathingTime = 1f;
        public float FullLungHoldingTime = 15f;
        public float LastEmptyLungHoldingTime = 0f;
    }
}