using UnityEngine;
using TMPro;

namespace TiagoTijolo
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private Timer timer = null;
        [SerializeField] private TextMeshProUGUI _timeText = null;
        [SerializeField] private string stringFormat = "F0";

        protected virtual void UpdateUI() 
        {
            _timeText.SetText(GetRemainingTime().ToString(stringFormat));
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