using BrickJump.Observer;
using BrickJump.Values;
using UnityEngine;

namespace BrickJump.Misc
{
    public class ScoreTracker : MonoBehaviour
    {
        [SerializeField] private GameEvent ReachedHighScoreEvent;
        [SerializeField] private IntReference currentScore, highScore;
        private bool reachedNewScore;

        private void Update()
        {
            if (!reachedNewScore)
            {
                if (currentScore > highScore && highScore > 0)
                {
                    ReachedHighScoreEvent.TriggerEvent();
                    reachedNewScore = true;
                }
            }
        }
    }
}