using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public int score;

    public void AddScore(int deltaScore)
    {
        score += deltaScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void Start()
    {
        score = 0;
        UpdateScore();
    }
}
