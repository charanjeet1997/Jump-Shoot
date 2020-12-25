using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameScoreManager : MonoBehaviour
{
    public GameScoreContainer scoreContainer;
    public Text scoreText;
    public static GameScoreManager Instance;
    public Text highScore;

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        scoreText.text = "0";
        scoreContainer.ResetCurrentScore();
        highScore.text = "High Score - "+scoreContainer.highScore;
    }
    public void UpdateScore(int score)
    {
        scoreContainer.AddScore(score);
        scoreText.text = scoreContainer.GetCurrentScore().ToString();
    }

    public void SetHighScore()
    {
        scoreContainer.ResetCurrentScore();
        scoreText.text = "0";
        highScore.text = "High Score - "+scoreContainer.highScore;
    }
}
