using StackJump.Values;
using TMPro;
using UnityEngine;

namespace StackJump.Player
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentScore;
        [SerializeField] private IntReference currentScoreReference;
        
        private void Update()
        {
            DisplayCurrent();
        }

        private void DisplayCurrent()
        {
            currentScore.text = $"{currentScoreReference.Value}";
        }
    }
} 