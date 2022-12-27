using StackJump.Values;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHighScore : MonoBehaviour
{
    [SerializeField] private IntVariable highScore;
    [SerializeField] private IntVariable currentScore;
    [SerializeField] private IntVariable colorScore;
    [SerializeField] private IntVariable transformScore;

    public void UpdateScore()
    {
        currentScore.ApplyChange(colorScore);
        currentScore.ApplyChange(transformScore);

        if (highScore.IntValue < currentScore.IntValue)
        {
            highScore.IntValue = currentScore.IntValue;
        }
    }
}