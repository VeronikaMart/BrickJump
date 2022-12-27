using StackJump.Values;
using TMPro;
using UnityEngine;

namespace StackJump.UI
{
    public class HighScoreDisplay : MonoBehaviour
    {
        [SerializeField] private SaveGame saveGame;
        [SerializeField] private IntReference highScore;
        [SerializeField] private TextMeshProUGUI highScoreText;

        private void OnEnable()
        {
            saveGame.OnLoad();
            highScoreText.text = $"High score: \n{highScore.Value}";
        }
    }
}