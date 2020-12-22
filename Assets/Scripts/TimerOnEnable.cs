namespace TiagoTijolo
{
    public class TimerOnEnable : Timer
    {
        public TimerData timerData = default;

        private void OnEnable()
        {
            BeginTimer(timerData.CountTime);
        }

        private void OnDisable()
        {
            StopTimer();
            OnTimerEnd.Invoke();
        }
    }
}