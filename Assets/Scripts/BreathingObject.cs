using UnityEngine;
using UnityEngine.UI;

namespace TiagoTijolo
{
    public class BreathingObject : MonoBehaviour
    {
        [SerializeField] private BreathingData breathingData = default;

        private float ScaleTime => breathingData.BreathingTime / 2f;

        public void Show()
        {
            GetComponent<Image>().enabled = true;
        }

        public void Hide()
        {
            GetComponent<Image>().enabled = false;
        }

        private void OnInpirationStarted()
        {
            iTween.ScaleTo(gameObject, iTween.Hash("time", ScaleTime, 
                                        "scale", Vector3.one * 3f, 
                                        "easetype", iTween.EaseType.linear));
        }

        private void OnExpirationStarted()
        {
            iTween.ScaleTo(gameObject, iTween.Hash("time", ScaleTime,
                                        "scale", Vector3.one,
                                        "easetype", iTween.EaseType.linear));

        }

        private void OnEnable()
        {
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