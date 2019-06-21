using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public int score = 0;
    public int maxPointsPerInteraction = 10;

    private Animator animator;

    // Adds points to the score depending on the accuracy of an interaction
    // accuracy - The accuracy is a value between -1 and 1 with 0 as optimum
    public void AddScore(float accuracy)
    {
        if (accuracy < -1 || accuracy > 1)
        {
            throw new System.ArgumentException("accuracy cannot be smaller than -1 or larger than 1");
        }

        int points = (int) Mathf.Ceil(
            maxPointsPerInteraction
            * Mathf.Cos(Mathf.PI / 2.0F * accuracy)
        );
        score += points;
        UpdateScore();
    }

    void UpdateScore()
    {
        if (score > 0)
        {
            animator.SetTrigger("ScoreUpdate");
        }
        scoreText.text = score.ToString();
    }

    void Start()
    {
        animator = scoreText.GetComponent<Animator>();
        UpdateScore();
    }
}

