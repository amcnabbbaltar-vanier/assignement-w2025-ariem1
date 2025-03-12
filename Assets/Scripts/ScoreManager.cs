using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
public static ScoreManager instance;
    public int score = 0; // Player's score
    public Text scoreText; // UI Text to display score (optional)

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
