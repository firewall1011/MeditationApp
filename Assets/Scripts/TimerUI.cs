using UnityEngine;
using TMPro;

namespace TiagoTijolo
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] protected Timer timer = null;
        [SerializeField] protected TextMeshProUGUI _timeText = null;
        [SerializeField] protected string stringFormat = "F0";

        protected virtual void UpdateUI() 
        {
            _timeText.SetText(GetPassedTime().ToString(stringFormat));
        }

        protected virtual void Update()
        {
            UpdateUI();
        }

        protected float GetPassedTime() => timer.TimeElapsed;
        protected float GetRemainingTime() => (timer.TimeLeft);
        protected float GetNormalizedTime() => (timer.TimeElapsed / timer.GetCountTime());
        protected float GetRemainingNormalizedTime() => (GetRemainingTime() / timer.GetCountTime());
    }
}