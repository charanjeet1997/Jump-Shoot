using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameScoreContainer",menuName = "ScoreContainer/GameScoreContainer")]
public class GameScoreContainer : ScriptableObject
{
    public int highScore;
    public int currentScore = 0;
    
    public void AddScore(int score){
        currentScore+= score;
        SetHighScore(currentScore);
    }

    public void SetHighScore(int score){
        if(score > highScore)
        {
            highScore = score;
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }
}
