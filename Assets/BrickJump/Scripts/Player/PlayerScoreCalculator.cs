using BrickJump.Values;
using UnityEngine;

namespace BrickJump.Player
{
    public class PlayerScoreCalculator : MonoBehaviour
    {
        [SerializeField] private IntVariable currentScore;

        private void Update()
        {
            CalculateCurrentScore(currentScore);
        }

        public void CalculateCurrentScore(IntVariable currentScore)
        {
            float playerPosY = transform.position.y;
            currentScore.IntValue = Mathf.Abs((int)playerPosY);
        }
    }
}