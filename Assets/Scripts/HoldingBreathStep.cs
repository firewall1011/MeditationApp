using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace TiagoTijolo
{
    public class HoldingBreathStep : MonoBehaviour
    {
        public UnityEvent OnStepConcluded = new UnityEvent();

        [Header("Scriptable Object Data")]
        [SerializeField] private BreathingData breathingData = null;
        [SerializeField] private TimerData inspirationTime = null;

        [Header("Timer UI")]
        [SerializeField] private Timer timer = null;
        [SerializeField] private TimerUI counterTimer = null;
        [SerializeField] private CountdownTimerUI countdownTimer = null;
        [SerializeField] private TMPro.TextMeshProUGUI lastEmptyLungTimeText = null;
        
        [Header("Actions")]
        [SerializeField] private InputActionReference changeStepActionRef = null;

        
        private InputAction changeStepAction = null;

        private bool emptyLung = true;
        private void Awake()
        {
            changeStepAction = changeStepActionRef.ToInputAction();
        }

        private void ChangeStep(InputAction.CallbackContext obj)
        {
            if (emptyLung)
            {
                emptyLung = false;

                timer.StopTimer();
                breathingData.LastEmptyLungHoldingTime = timer.TimeElapsed;
                timer.RestartTimer();

                breathingData.OnInspirationStarted.Invoke();
                timer.SetCountTime(breathingData.FullLungHoldingTime);
                Invoke(nameof(BeginFullLungStep), inspirationTime.CountTime);
                
                counterTimer.enabled = false;
                countdownTimer.enabled = true;
                lastEmptyLungTimeText.gameObject.SetActive(false);
            }
        }

        private void BeginFullLungStep()
        {
            timer.BeginTimer();
            timer.OnTimerEnd.AddListener(EndHoldingBreathStep);
        }

        private void EndHoldingBreathStep()
        {
            timer.OnTimerEnd.RemoveListener(EndHoldingBreathStep);
            breathingData.OnExpirationStarted.Invoke();
            OnStepConcluded.Invoke();
        }

        private void BeginEmptyLungStep()
        {
            counterTimer.enabled = true;
            countdownTimer.enabled = false;
            lastEmptyLungTimeText.gameObject.SetActive(true);
            
            timer.BeginTimer(Mathf.Infinity);
            lastEmptyLungTimeText.SetText(breathingData.LastEmptyLungHoldingTime.ToString("F2"));

            emptyLung = true;
        }

        private void OnEnable()
        {
            BeginEmptyLungStep();
            changeStepAction.Enable();
            changeStepAction.started += ChangeStep;
        }

        private void OnDisable()
        {
            changeStepAction.Disable();
            changeStepAction.started -= ChangeStep;
        }
    }
}