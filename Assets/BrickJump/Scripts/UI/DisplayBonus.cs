using StackJump.Values;
using System.Collections;
using TMPro;
using UnityEngine;

namespace StackJump.UI
{
    public class DisplayBonus : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] bonuces;
        [SerializeField] private IntReference transformBonusValue;
        [SerializeField] private IntReference colorBonusValue;
        [SerializeField] private float displayTimer = 1f;
        
        public void DisplayTransform()
        {
            StartCoroutine(TransformBonusTimer());
        }

        public void DisplayColor()
        {
            StartCoroutine(ColorBonusTimer());
        }

        IEnumerator TransformBonusTimer()
        {
            bonuces[0].gameObject.SetActive(true);
            yield return new WaitForSeconds(displayTimer);
            bonuces[0].gameObject.SetActive(false);
        }

        IEnumerator ColorBonusTimer()
        {
            bonuces[1].gameObject.SetActive(true);
            yield return new WaitForSeconds(displayTimer);
            bonuces[1].gameObject.SetActive(false);
        }

        //private void State(bool state)
        //{
        //    bonuces[0].gameObject.SetActive(state);
        //}
    }
}