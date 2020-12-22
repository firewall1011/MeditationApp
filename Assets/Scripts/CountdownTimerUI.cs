namespace TiagoTijolo
{
    public class CountdownTimerUI : TimerUI
    {
        protected override void UpdateUI()
        {
            _timeText.SetText(GetRemainingTime().ToString(stringFormat));
        }
    }
}