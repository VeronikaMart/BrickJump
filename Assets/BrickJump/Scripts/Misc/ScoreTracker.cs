using StackJump.Observer;
using StackJump.Values;
using UnityEngine;

namespace StackJump.Misc
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