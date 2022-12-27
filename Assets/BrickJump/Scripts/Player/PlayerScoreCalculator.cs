using StackJump.Values;
using UnityEngine;

namespace StackJump.Player
{
    public class PlayerScoreCalculator : MonoBehaviour
    {
        [SerializeField] private IntVariable currentScore;

        private void Update()
        {
            // If gamePlaying
            CalculateCurrentScore(currentScore);
        }

        public void CalculateCurrentScore(IntVariable currentScore)
        {
            float playerPosY = transform.position.y;
            currentScore.IntValue = Mathf.Abs((int)playerPosY);
        }
    }
}