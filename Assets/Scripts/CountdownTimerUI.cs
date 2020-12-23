using UnityEngine;

namespace TiagoTijolo
{
    public class CountdownTimerUI : TimerUI
    {
        protected override void UpdateUI()
        {
            _timeText.SetText(Mathf.CeilToInt(GetRemainingTime()).ToString(stringFormat));
        }
    }
}