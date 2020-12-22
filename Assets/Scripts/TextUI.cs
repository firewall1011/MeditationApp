using UnityEngine;
using TMPro;

namespace TiagoTijolo
{
    public class TextUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh = default;
        [SerializeField] private string stringFormat = "F0";

        public void SetText(int text)
        {
            textMesh.SetText(text.ToString(stringFormat));
        }

        public void SetText(float text)
        {
            textMesh.SetText(text.ToString(stringFormat));
        }

        public void SetText(string text)
        {
            textMesh.SetText(string.Format(stringFormat, text));
        }
    }
}