using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText; // The text to display the high score
    [SerializeField] private ScoreScript scoreScript; // Reference to the ScoreScript

    private int highScore = 0; // To store the current high score
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        // Initialize the high score text
        highScoreText.text = highScore.ToString();
    }

    void Update()
    {
        // Check if the current score is higher than the high score
        if (scoreScript.score > highScore)
        {
            highScore = scoreScript.score; // Update the high score
            highScoreText.text = highScore.ToString(); // Update the high score text
        }
    }
}
