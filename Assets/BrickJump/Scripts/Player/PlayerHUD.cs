using BrickJump.Values;
using TMPro;
using UnityEngine;

namespace BrickJump.Player
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