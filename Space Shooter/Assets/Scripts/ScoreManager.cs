using UnityEngine;
using UnityEngine.UI; // Include this for UI elements

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // The score variable to keep track of the score
    public Text scoreText; // UI Text to display the score

    void Start()
    {
        // Update the score display at the start
        UpdateScoreText();
    }

    // Function to increase score by a specific value
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Function to update the score text UI
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
