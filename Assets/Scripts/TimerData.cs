using UnityEngine;

namespace TiagoTijolo
{
    [CreateAssetMenu(fileName = "TimerAsset", menuName = "TimerData", order = 0)]
    public class TimerData : ScriptableObject
    {
        public float CountTime = 0f;
    }
}
