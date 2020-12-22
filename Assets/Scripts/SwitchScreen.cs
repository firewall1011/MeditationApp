using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TiagoTijolo
{
    public class SwitchScreen : MonoBehaviour
    {
        [SerializeField] private GameObject nextScreen = default;

        public void Switch()
        {
            nextScreen.SetActive(true);
            gameObject.SetActive(false);
        }

        public void Switch(GameObject switchScreen)
        {
            switchScreen.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
